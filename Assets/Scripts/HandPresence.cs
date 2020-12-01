using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;
    public GameObject pointerModelPrefab;
    
    private InputDevice targetDevice;
    private GameObject spawnedHandModel;
    private GameObject spawnedPointerModel;
    private Animator handAnimator;
    private bool isPointerOpen;
    private bool isPressing;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    void TryInitialize () 
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0) {
            targetDevice = devices[0];

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();

            spawnedPointerModel = Instantiate(pointerModelPrefab, transform);
            spawnedPointerModel.SetActive(false);
        }
    }

    void UpdateHandAnimation() 
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) 
        { 
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else 
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue)) 
        { 
            handAnimator.SetFloat("Grip", gripValue);
        }
        else 
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid) 
        {
            TryInitialize();
        }
        else {

            if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary) && primary) 
            { 
                if (!isPressing)
                {
                    isPressing = true;
                    isPointerOpen = !isPointerOpen;

                    if (!isPointerOpen)
                    {
                        spawnedHandModel.SetActive(true);
                        spawnedPointerModel.SetActive(false);
                    }
                    else
                    {
                        spawnedHandModel.SetActive(false);
                        spawnedPointerModel.SetActive(true);
                    }
                }
            }
            else
            {
                isPressing = false;
            }

            if (!isPointerOpen)
            {
                UpdateHandAnimation();
            }
        }
    }
}
