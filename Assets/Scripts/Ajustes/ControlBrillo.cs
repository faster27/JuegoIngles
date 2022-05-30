using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBrillo : MonoBehaviour
{

    public Slider SliderBrillo;
    public float SliderValue;
    public Image PanelBrillo;
    public GameObject[] PanelesBrillo;
    // Start is called before the first frame update
    void Start()
    {
        PanelesBrillo=GameObject.FindGameObjectsWithTag("PanelBrillo");

        
        SliderBrillo.value=PlayerPrefs.GetFloat("Brillo",0f);

       
        
        
    }

    // Update is called once per frame
    void Update()
    {
         foreach(GameObject Panel_Brillo in PanelesBrillo)
        {


            Panel_Brillo.GetComponent<Image>().color= new Color(PanelBrillo.color.r,PanelBrillo.color.g,PanelBrillo.color.b,SliderBrillo.value);



        }
    }

    public void GuardarBrillo()
    {
        
        PlayerPrefs.SetFloat("Brillo",SliderBrillo.value);
        

    }
}
