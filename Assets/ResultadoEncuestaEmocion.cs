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

    List<float> EmocionNumerica = new List<float>();
    List<string> EmocionNombre = new List<string>();
   

    
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

        return ValorResultado;
    }
     
    public void ElegirMayor()
    {   
        float ValorMayor;
        int Posicion;
        List<float> Lista = new List<float>();
        List<string> ListaNombres = new List<string>();

        Lista.Add(ValorAlegria);
        Lista.Add(ValorTristeza);
        Lista.Add(ValorMiedo);
        Lista.Add(ValorIra);

        ListaNombres.Add("Alegria");
        ListaNombres.Add("Tristeza");
        ListaNombres.Add("Miedo");
        ListaNombres.Add("Ira");

        bool Repeticion= HayRepetidos(Lista);

        if(Repeticion){

            //Se entra en este if si el array que contiene los valores numericos de las emociones
            //viene con al menos dos valores iguales
            
            MezclarListas(Lista,ListaNombres);

            ValorMayor=EmocionNumerica.Max();

            Posicion=EmocionNumerica.IndexOf(ValorMayor);

            //Las emociones se dividen en Alta y Baja para asi despues encontrar la dificultad
            EmocionResultante=ClasificarEmocionAlta_Baja(ValorMayor,EmocionNombre, Posicion);

            Debug.Log("La emocion ganadora es: " + EmocionResultante);

        }else{
            
            //Si el array no tiene iguales lo que hace es sacar el numero mayor
            //y clasificar en emocion alta o baja 

            ValorMayor=Lista.Max();

            Posicion=Lista.IndexOf(ValorMayor);

            ResultadoEmocion=ClasificarEmocionAlta_Baja(ValorMayor,ListaNombres, Posicion);
                
            Debug.Log("La emocion ganadora es: " + ResultadoEmocion);

            EmocionResultante=ResultadoEmocion;
            
        }
    }

    public string ClasificarEmocionAlta_Baja(float ValorMayor, List<string> EmocionNombre, int Posicion){

       Debug.Log("ValorMayor: " + ValorMayor + ", "+ "Emocion: " + EmocionNombre[Posicion]);
       
       
        if(EmocionNombre[Posicion]== "Alegria"){

            if(ValorMayor<=5.1f){

                EmocionResultante="Alegria-Baja";

            }else{

                EmocionResultante="Alegria-Alta";

            }
        }

        if(EmocionNombre[Posicion]== "Tristeza"){

            if(ValorMayor<=5.1f){

                EmocionResultante="Tristeza-Baja";

            }else{

                EmocionResultante="Tristeza-Alta";

            }
        }

        if(EmocionNombre[Posicion]== "Ira"){

            if(ValorMayor<=5.1f){

                EmocionResultante="Ira-Baja";

            }else{

                EmocionResultante="Ira-Alta";

            }
        }

          if(EmocionNombre[Posicion]== "Miedo"){

            if(ValorMayor<=5.1f){

                EmocionResultante="Miedo-Baja";

            }else{

                EmocionResultante="Miedo-Alta";

            }
        }

        return EmocionResultante;
    }


    public bool HayRepetidos(List<float> lista){

        bool EstaRepetido=false;

        // Creas la nueva
        List<float> listaNueva = new List<float>();

        for (int i = 0; i < lista.Count; i++)
        {
            if (!(listaNueva.Contains(lista[i])))
            {
                listaNueva.Add(lista[i]);
            }else{

                EstaRepetido=true;

            }
        }

        return EstaRepetido;

    }


    public void MezclarListas(List<float> ListaNumeros, List<string> ListaNombres){

        int n = ListaNumeros.Count;
        int ValorRandom;
        float TempNumerico;
        string TempNombre;

        for( int i=0; i <n; i++){

            ValorRandom=Random.Range(0,n);

            TempNumerico= ListaNumeros[ValorRandom];
            TempNombre=ListaNombres[ValorRandom];

            ListaNumeros[ValorRandom]=ListaNumeros[i];
            ListaNombres[ValorRandom]=ListaNombres[i];

            ListaNumeros[i]= TempNumerico;
            ListaNombres[i]=TempNombre;

        }

        EmocionNumerica=ListaNumeros;
        EmocionNombre=ListaNombres;

        

    }
}
