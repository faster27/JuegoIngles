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

    List<float> ListaValoresEmociones = new List<float>();

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

            EmocionResultante=ClasificarEmocionAlta_Baja(ValorMayor,listaNombresRepetidos, posicion,ListaValoresEmociones);

        }

        if(señal==2){

            int posicion=listaNombresRepetidos.IndexOf("Tristeza");

            float ValorMayor=listaPuntajesRepetidos[posicion];

            EmocionResultante=ClasificarEmocionAlta_Baja(ValorMayor,listaNombresRepetidos, posicion, ListaValoresEmociones);

        }

        if(señal==3){

            int posicion=listaNombresRepetidos.IndexOf("Ira");

            float ValorMayor=listaPuntajesRepetidos[posicion];

            EmocionResultante=ClasificarEmocionAlta_Baja(ValorMayor,listaNombresRepetidos, posicion, ListaValoresEmociones);

        }

        if(señal==4){

            int posicion=listaNombresRepetidos.IndexOf("Miedo");

            float ValorMayor=listaPuntajesRepetidos[posicion];

            EmocionResultante=ClasificarEmocionAlta_Baja(ValorMayor,listaNombresRepetidos, posicion, ListaValoresEmociones);

        }
        
        
        
       

        
                
        Debug.Log("La emocion ganadora es: " + EmocionResultante);


    }
     
    public void ElegirMayor()
    {   
        float ValorMayor;
        int Posicion;

        
        
        List<string> ListaNombres = new List<string>();

        ListaValoresEmociones.Add(ValorAlegria);
        ListaValoresEmociones.Add(ValorTristeza);
        ListaValoresEmociones.Add(ValorMiedo);
        ListaValoresEmociones.Add(ValorIra);

        ListaNombres.Add("Alegria");
        ListaNombres.Add("Tristeza");
        ListaNombres.Add("Miedo");
        ListaNombres.Add("Ira");

        bool Repeticion= HayRepetidos(ListaValoresEmociones,ListaNombres);

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

            ValorMayor=ListaValoresEmociones.Max();

            Posicion=ListaValoresEmociones.IndexOf(ValorMayor);

            ResultadoEmocion=ClasificarEmocionAlta_Baja(ValorMayor,ListaNombres, Posicion, ListaValoresEmociones);
                
            Debug.Log("La emocion ganadora es: " + ResultadoEmocion);

            EmocionResultante=ResultadoEmocion;
            
        }
    }

    public string ClasificarEmocionAlta_Baja(float ValorMayor, List<string> EmocionNombre, int Posicion, List<float> ListaValoresEmociones){

       Debug.Log("ValorMayor: " + ValorMayor + ", "+ "Emocion: " + EmocionNombre[Posicion]);
       
       
        if(EmocionNombre[Posicion]== "Alegria"){

            if(ValorMayor<=5.0f){

                EmocionResultante="Alegria-Baja";

            }else{

                EmocionResultante="Alegria-Alta";

            }
        }

        if(EmocionNombre[Posicion]== "Tristeza"){

            if(ValorMayor<=5.0f){

                EmocionResultante="Tristeza-Baja";

            }else{

                EmocionResultante="Tristeza-Alta";

            }
        }

        if(EmocionNombre[Posicion]== "Ira"){

            float PuntuacionAlegria= ListaValoresEmociones[0]; //lista valores en 0 me trae la puntuacion de alegria
            float Puntuaciontristeza= ListaValoresEmociones[1]; //lista valores en 1 me trae la puntuacion de tristeza

            if(Puntuaciontristeza>PuntuacionAlegria){
  
                EmocionResultante="Ira-Baja";

            }else if(PuntuacionAlegria>Puntuaciontristeza){

                EmocionResultante="Ira-Alta";

            }else{

                int random=Random.Range(1,3);

                if(random==1){
                    EmocionResultante="Ira-Baja";

                }else{
                    EmocionResultante="Ira-Alta";
                }


            }
        }

        if(EmocionNombre[Posicion]== "Miedo"){

            float PuntuacionAlegria= ListaValoresEmociones[0]; //lista valores en 0 me trae la puntuacion de alegria
            float Puntuaciontristeza= ListaValoresEmociones[1]; //lista valores en 1 me trae la puntuacion de tristeza

            if(Puntuaciontristeza>PuntuacionAlegria){
  
                EmocionResultante="Miedo-Baja";

            }else if(PuntuacionAlegria>Puntuaciontristeza){

                EmocionResultante="Miedo-Alta";

            }else{

                int random=Random.Range(1,3);

                if(random==1){
                    EmocionResultante="Miedo-Baja";

                }else{
                    EmocionResultante="Miedo-Alta";
                }


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
                  
                    if(!index.Contains(j)){
                        index.Add(j);
                        contador+=1;

                    }
                    
                    
                }      
            }

            contador-=1;


            if(contador==0){

                index.RemoveAt(0);
            }

           

            if(contador==1 && !listaPuntajesRepetidos.Contains(num)){


                if(index.Count==2){
                    if(!listaNombresRepetidos.Contains(listaNombres[index[0]])  ){
                    
                    listaNombresRepetidos.Add(listaNombres[index[0]]);
                    listaPuntajesRepetidos.Add(num);

                    }
                    
                    if(!listaNombresRepetidos.Contains(listaNombres[index[1]])){
                    
                    listaNombresRepetidos.Add(listaNombres[index[1]]);
                    listaPuntajesRepetidos.Add(num);

                    }
                }
                
                if(index.Count==4){

                    if(!listaNombresRepetidos.Contains(listaNombres[index[2]])  ){
                    
                    listaNombresRepetidos.Add(listaNombres[index[2]]);
                    listaPuntajesRepetidos.Add(num);

                    }
                    
                    if(!listaNombresRepetidos.Contains(listaNombres[index[3]])){
                    
                    listaNombresRepetidos.Add(listaNombres[index[3]]);
                    listaPuntajesRepetidos.Add(num);

                    }
                }
 
                float maximo=lista.Max();


                if(listaPuntajesRepetidos.Count==4){
                    
                    Debug.Log(listaNombresRepetidos[0] + listaNombresRepetidos[1] + listaNombresRepetidos[2] + listaNombresRepetidos[3]);
                    Debug.Log("tamaño puntaje: " + listaPuntajesRepetidos.Count + " Tamaño nombres: " + listaNombresRepetidos.Count);

                    float maximoPuntaje=listaPuntajesRepetidos.Max();
                    float minimoPuntaje=listaPuntajesRepetidos.Min();

                    int index2=listaPuntajesRepetidos.IndexOf(minimoPuntaje);
                    listaPuntajesRepetidos.RemoveAt(index2);
                    listaNombresRepetidos.RemoveAt(index2);

                    Debug.Log("tamaño puntaje: " + listaPuntajesRepetidos.Count + " Tamaño nombres: " + listaNombresRepetidos.Count);

                    int index3=listaPuntajesRepetidos.IndexOf(minimoPuntaje);
                    listaPuntajesRepetidos.RemoveAt(index3);
                    listaNombresRepetidos.RemoveAt(index3);

                    Debug.Log("tamaño puntaje: " + listaPuntajesRepetidos.Count + " Tamaño nombres: " + listaNombresRepetidos.Count);

                    EstaRepetido=true;

                    Debug.Log(listaNombresRepetidos[0] + "     " + listaNombresRepetidos[1]);


                }else{

                    
                    
                    if(maximo>listaPuntajesRepetidos[0] &&  maximo>listaPuntajesRepetidos[1]  ){

                        EstaRepetido=false;
                    }else{

                        EstaRepetido=true;
                    }

                }

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


            
   
            contador=0;
  
        }

        //Debug.Log("Lista[0]  " + listaPuntajesRepetidos[0] + "---" + "Lista[1]  " + listaPuntajesRepetidos[1]);
       // Debug.Log("Tamaño de lista nombres  " + listaNombresRepetidos.Count);
       // Debug.Log("Nombre[0]  " + listaNombresRepetidos[0] + "---" + "Nombre[1]  " + listaNombresRepetidos[1]);

        return EstaRepetido;

    }


    
}
