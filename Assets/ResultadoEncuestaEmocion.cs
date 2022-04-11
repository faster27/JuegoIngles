using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class ResultadoEncuestaEmocion : MonoBehaviour
{

    //Aqui se realiza todo el proceso para obener la emcoion con la cual se realizara las preguntas 
    //al momento de coger la llave y abrir la puerta

  
    float ValorAlegria=0;
    float ValorTristeza=0;
    float ValorMiedo=0;
    float ValorIra=0;

    public static string EmocionResultante;
    string ResultadoEmocion;

    public GameObject[] Toggles1;
    public GameObject[] Toggles2;
    public GameObject[] Toggles3;
    public GameObject[] Toggles4;
   

    
    public void CalcularPuntuacionAlegria(){
           
            Toggles1=GameObject.FindGameObjectsWithTag("Alegria");
            Toggles2=GameObject.FindGameObjectsWithTag("Optimista");
            Toggles3=GameObject.FindGameObjectsWithTag("Jovial");
            Toggles4=GameObject.FindGameObjectsWithTag("Contento");

        ValorAlegria=SacarPuntuacion(Toggles1,Toggles2,Toggles3,Toggles4);

       
            
    }

    public void CalcularPuntuacionTristeza(){
           
            Toggles1=GameObject.FindGameObjectsWithTag("Melancolico");
            Toggles2=GameObject.FindGameObjectsWithTag("Alicaido");
            Toggles3=GameObject.FindGameObjectsWithTag("Apagado");
            Toggles4=GameObject.FindGameObjectsWithTag("Triste");

        ValorTristeza=SacarPuntuacion(Toggles1,Toggles2,Toggles3,Toggles4);

       
            
    }

      public void CalcularPuntuacionIra(){
           
            Toggles1=GameObject.FindGameObjectsWithTag("Irritado");
            Toggles2=GameObject.FindGameObjectsWithTag("Enojado");
            Toggles3=GameObject.FindGameObjectsWithTag("Molesto");
            Toggles4=GameObject.FindGameObjectsWithTag("Enfadado");

        ValorIra=SacarPuntuacion(Toggles1,Toggles2,Toggles3,Toggles4);

        
            
    }

    public void CalcularPuntuacionMiedo(){
           
            Toggles1=GameObject.FindGameObjectsWithTag("Nervioso");
            Toggles2=GameObject.FindGameObjectsWithTag("Tenso");
            Toggles3=GameObject.FindGameObjectsWithTag("Ansioso");
            Toggles4=GameObject.FindGameObjectsWithTag("Intranquilo");

        ValorMiedo=SacarPuntuacion(Toggles1,Toggles2,Toggles3,Toggles4);

       
            
    }

    public float SacarPuntuacion(GameObject[] Toggles1, GameObject[] Toggles2, GameObject[] Toggles3,  GameObject[] Toggles4   ){

        float ValorResultado=0f;
        
        foreach(GameObject Toggle in Toggles1)
        {
            
            Toggle m_Toggle = Toggle.GetComponent<Toggle>();
            if(m_Toggle.isOn){

               int index = System.Array.IndexOf(Toggles1, Toggle);
               
                ValorResultado=ValorResultado+index;

            }

        }

        foreach(GameObject Toggle in Toggles2)
        {
            
            Toggle m_Toggle = Toggle.GetComponent<Toggle>();
            if(m_Toggle.isOn){

               int index = System.Array.IndexOf(Toggles2, Toggle);
               
                ValorResultado=ValorResultado+index;

            }

        }

        foreach(GameObject Toggle in Toggles3)
        {
            
            Toggle m_Toggle = Toggle.GetComponent<Toggle>();
            if(m_Toggle.isOn){

               int index = System.Array.IndexOf(Toggles3, Toggle);
               
                ValorResultado=ValorResultado+index;

            }

        }

        foreach(GameObject Toggle in Toggles4)
        {
            
            Toggle m_Toggle = Toggle.GetComponent<Toggle>();
            if(m_Toggle.isOn){

               int index = System.Array.IndexOf(Toggles4, Toggle);
               
                ValorResultado=ValorResultado+index;

            }

        }

        

        ValorResultado=ValorResultado/4.0f;

        Debug.Log(ValorResultado);

        return ValorResultado;



    }
    

       
    public void ElegirMayor()
    {
        
        float ValorMayor;
        int Posicion;
        List<float> Lista = new List<float>();

        Lista.Add(ValorAlegria);
        Lista.Add(ValorTristeza);
        Lista.Add(ValorMiedo);
        Lista.Add(ValorIra);

        ValorMayor=Lista.Max();

        //Me saca el index de la primera aparicion del valor mayor
        
        Posicion=Lista.IndexOf(ValorMayor);

        if(Posicion==0){

            ResultadoEmocion="Alegria";
        }

         if(Posicion==1){

            ResultadoEmocion="Tristeza";
        }

         if(Posicion==2){

            ResultadoEmocion="Miedo";
        }

         if(Posicion==3){

            ResultadoEmocion="Ira";
        }

        Debug.Log("La emocion ganadora es: " + ResultadoEmocion);

        EmocionResultante=ResultadoEmocion;

    }
}
