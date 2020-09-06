using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;
    
    private InputDevice targetDevice;
    private GameObject spawnedHandModel;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    void TryInitialize () {

        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0) {
            targetDevice = devices[0];

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            Debug.Log(spawnedHandModel.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid) {
            TryInitialize();
        }

        
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue) {
            //Debug.Log("Primary button pressed");
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f) {
            //Debug.Log("trigger pressed" + triggerValue);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero) {
            //Debug.Log("Primary touchpad" + primary2DAxisValue);
        }
    }
}
