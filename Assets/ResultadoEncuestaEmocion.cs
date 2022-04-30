using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;



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

    

    public Button BtnAlegriaRepeticion;
    public Button BtnTristezaRepeticion;
    public Button BtnIraRepeticion;
    public Button BtnMiedoRepeticion;

    List<float> EmocionNumerica = new List<float>();
    List<string> EmocionNombre = new List<string>();

    // Listas que sirven para l solucion de las emociones con puntajes iguales
    List<float> listaPuntajesRepetidos = new List<float>();
    List<string> listaNombresRepetidos = new List<string>();
   
    public GameObject PanelEmocionesEmpatadas;

    public GameObject Jugador;
    public GameObject Calavera;

    string level;

    void Start () {
	    //BtnRepeticionAlegria = BtnAlegriaRepeticion.GetComponent<Button>();
		BtnAlegriaRepeticion.onClick.AddListener(() => ResultadoEmocionParaRepeticion(1));

       // BtnRepeticionTristeza = BtnTristezaRepeticion.GetComponent<Button>();
		BtnTristezaRepeticion.onClick.AddListener(() => ResultadoEmocionParaRepeticion(2));

       // BtnRepeticionIra = BtnIraRepeticion.GetComponent<Button>();
		BtnIraRepeticion.onClick.AddListener(() => ResultadoEmocionParaRepeticion(3));

       // BtnRepeticionMiedo = BtnMiedoRepeticion.GetComponent<Button>();
		BtnMiedoRepeticion.onClick.AddListener(() => ResultadoEmocionParaRepeticion(4));

        Scene scene2 = SceneManager.GetActiveScene();
        level =scene2.name;

         

	}
    
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


    public void ResultadoEmocionParaRepeticion(int señal){

        
        if(señal==1){

            int posicion=listaNombresRepetidos.IndexOf("Alegria");

            float ValorMayor=listaPuntajesRepetidos[posicion];

            EmocionResultante=ClasificarEmocionAlta_Baja(ValorMayor,listaNombresRepetidos, posicion);

        }

        if(señal==2){

            int posicion=listaNombresRepetidos.IndexOf("Tristeza");

            float ValorMayor=listaPuntajesRepetidos[posicion];

            EmocionResultante=ClasificarEmocionAlta_Baja(ValorMayor,listaNombresRepetidos, posicion);

        }

        if(señal==3){

            int posicion=listaNombresRepetidos.IndexOf("Ira");

            float ValorMayor=listaPuntajesRepetidos[posicion];

            EmocionResultante=ClasificarEmocionAlta_Baja(ValorMayor,listaNombresRepetidos, posicion);

        }

        if(señal==4){

            int posicion=listaNombresRepetidos.IndexOf("Miedo");

            float ValorMayor=listaPuntajesRepetidos[posicion];

            EmocionResultante=ClasificarEmocionAlta_Baja(ValorMayor,listaNombresRepetidos, posicion);

        }
        
        
        
       

        
                
        Debug.Log("La emocion ganadora es: " + EmocionResultante);


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

        bool Repeticion= HayRepetidos(Lista,ListaNombres);

        if(Repeticion){

            //Se entra en este if si el array que contiene los valores numericos de las emociones
            //viene con al menos dos valores iguales
            
            //nueva propuesta, si hay repeticion se le debe preguntar al estduiante cual de las eociones empatadas prefiere 
            
            PanelEmocionesEmpatadas.SetActive(true);
            Jugador.SetActive(false);

            if(level=="Nivel4Mundo3"){

                Calavera.SetActive(false);

            }

            if(!listaNombresRepetidos.Contains("Alegria")){

                BtnAlegriaRepeticion.interactable=false;

            }
            if(!listaNombresRepetidos.Contains("Tristeza")){

                 BtnTristezaRepeticion.interactable=false;
                
            }
            if(!listaNombresRepetidos.Contains("Ira")){

                 BtnIraRepeticion.interactable=false;
                
            }
            if(!listaNombresRepetidos.Contains("Miedo")){

                 BtnMiedoRepeticion.interactable=false;
                
            }
            

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



    public bool HayRepetidos(List<float> lista, List<string> listaNombres){

        bool EstaRepetido=false;

        List<int> index=new List<int>();
       
        int contador=0;
        for (int i = 0; i < lista.Count; i++)
        {
            float num= lista[i];
            
            for (int j = 0; j < lista.Count; j++)
            {
                
                if(lista[j]==num){
                  // listaPuntajesRepetidos.Add(lista[j]);
                    index.Add(j);
                    contador+=1;
                }      
            }

            contador-=1;

            if(contador==0){

                index.RemoveAt(0);
            }

           

            if(contador==1 && !listaPuntajesRepetidos.Contains(num)){
                listaPuntajesRepetidos.Add(num);
                listaPuntajesRepetidos.Add(num);

                float maximo=lista.Max();
                if(maximo>listaPuntajesRepetidos[0] &&  maximo>listaPuntajesRepetidos[1]  ){

                     EstaRepetido=false;
                 }else{

                     EstaRepetido=true;
                 }

                listaNombresRepetidos.Add(listaNombres[index[0]]);
                listaNombresRepetidos.Add(listaNombres[index[1]]);

                index.RemoveAt(0);
                index.RemoveAt(0);

               

            }

            if(contador==2 && !listaPuntajesRepetidos.Contains(num)){

               

                listaPuntajesRepetidos.Add(num);
                listaPuntajesRepetidos.Add(num);
                listaPuntajesRepetidos.Add(num);

                float maximo=lista.Max();

                 if(maximo>listaPuntajesRepetidos[0] &&  maximo>listaPuntajesRepetidos[1] && maximo>listaPuntajesRepetidos[2] ){

                     EstaRepetido=false;
                 }else{

                     EstaRepetido=true;
                 }

                
                listaNombresRepetidos.Add(listaNombres[index[0]]);
                listaNombresRepetidos.Add(listaNombres[index[1]]);
                listaNombresRepetidos.Add(listaNombres[index[2]]);

                

               

               

            }
            
            if(contador==3 && !listaPuntajesRepetidos.Contains(num)){
                listaPuntajesRepetidos.Add(num);
                listaPuntajesRepetidos.Add(num);
                listaPuntajesRepetidos.Add(num);
                listaPuntajesRepetidos.Add(num);

                listaNombresRepetidos.Add(listaNombres[index[0]]);
                listaNombresRepetidos.Add(listaNombres[index[1]]);
                listaNombresRepetidos.Add(listaNombres[index[2]]);
                listaNombresRepetidos.Add(listaNombres[index[3]]);

                EstaRepetido=true;

                

            }


            if(listaPuntajesRepetidos.Count==4){   

                float max = listaPuntajesRepetidos.Max();
                float min = listaPuntajesRepetidos.Min();

                if(!(max==min)){

                    int index1= listaPuntajesRepetidos.IndexOf(min);
                    listaPuntajesRepetidos.RemoveAt(index1);
                    listaNombresRepetidos.RemoveAt(index1);

                    int index2=listaPuntajesRepetidos.IndexOf(min);
                    listaPuntajesRepetidos.RemoveAt(index2);
                    listaNombresRepetidos.RemoveAt(index2);

                    

                }

            }
   
            contador=0;
  
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
