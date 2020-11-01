using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    public Material[] normalMaterials;
    public Material[] highLightMaterials;
    public GameObject description;
    InteractableElement[] interactableElements;
    bool highLighed = false;

    void Start ()
    {
        interactableElements = FindObjectsOfType<InteractableElement>();
    }

    public void onSelect () 
    {
        for (int i = 0; i < interactableElements.Length; i++)
        {
            interactableElements[i].hideDescription();
        }

        description.SetActive(true);
    }

    public void onHoverEnter () 
    {
        this.GetComponent<Renderer>().materials = highLightMaterials;
        highLighed = true;
    }

    public void onHoverExit () 
    {
        this.GetComponent<Renderer>().materials = normalMaterials;
        highLighed = false;
    }

    public void hideDescription ()
    {
        if (!highLighed)
        {
            description.SetActive(false);   
        }
    }
}