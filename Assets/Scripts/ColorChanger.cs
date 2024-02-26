using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public Slider slider;
    public GameObject ground;

    public Material[] materials;

    public void changeColor()
    {
        switch (slider.value)
        {
            case 0:
                ground.GetComponent<Renderer>().material = materials[0];
                break;
            case 1:
                ground.GetComponent<Renderer>().material = materials[1];
                break;
            case 2:
                ground.GetComponent<Renderer>().material = materials[2];
                break;
        } 
    }
}
