using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class InteractableElement 
{
    public GameObject element;
    public Material normalMaterial;
    public Material highLightMaterial;
    public GameObject descrition;

    public bool highLighted = false;
    public bool selected = false;


    public void select () {

    }

    public void highLight () {

    }

    public void removeHighLight () {
        
    }
}