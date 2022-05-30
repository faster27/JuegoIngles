using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVolumen : MonoBehaviour
{      
    public Slider sliderVolumen;

    public GameObject[] Sonidos;

    // Start is called before the first frame update
    void Start()
    {
        Sonidos=GameObject.FindGameObjectsWithTag("Sonidos");
        sliderVolumen.value= PlayerPrefs.GetFloat("VolumenAGuardar",0.5f);

    }

    void Update()
    {

        foreach(GameObject sonido in Sonidos)
        {

            sonido.GetComponent<AudioSource>().volume=sliderVolumen.value;



        }


    }

    public void GuardarVolumen()
    {

        PlayerPrefs.SetFloat("VolumenAGuardar",sliderVolumen.value);

    }

    
}
