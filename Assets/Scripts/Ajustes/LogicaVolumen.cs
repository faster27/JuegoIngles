using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image ImagenMute;
    
    
    // Start is called before the first frame update
    void Start()
    {
        slider.value=PlayerPrefs.GetFloat("volumenAudio",0.5f);
        AudioListener.volume=slider.value;
        RevisarSiEstoyMute();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue=valor;
        PlayerPrefs.SetFloat("VolumenAudio",sliderValue);
        AudioListener.volume=slider.value;
        RevisarSiEstoyMute();


    }

    public void RevisarSiEstoyMute()
    {
        if(sliderValue==0)
        {
            ImagenMute.enabled=true;

        }else
        {

            ImagenMute.enabled=false;
        }



    }

    
}
