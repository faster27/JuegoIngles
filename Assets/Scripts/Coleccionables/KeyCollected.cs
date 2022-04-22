using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyCollected : MonoBehaviour
{
    public AudioSource clip;
    public GameObject Key;
    public GameObject PanelPreguntas;
    public static bool IsKeyCollected=false;

 
    public Button Btn1;
    public Button Btn2;
    public Button Btn3;

    public Button BtnSgtePregunta;

    public GameObject Llave;

    private ControlPreguntas ControlPreguntas; 

    int ContadorPreguntas=0;



    //Referencia a los textos de pregunta y respuesta del panel

    public TextMeshProUGUI TextoPregunta;
    public TextMeshProUGUI TextoRespuesta;

    void Start () {
		Button Btn11 = Btn1.GetComponent<Button>();
		Btn11.onClick.AddListener(() => ObtenerRespuesta(1));

        Button Btn22 = Btn2.GetComponent<Button>();
		Btn22.onClick.AddListener(() => ObtenerRespuesta(2));

        Button Btn33 = Btn3.GetComponent<Button>();
		Btn33.onClick.AddListener(() => ObtenerRespuesta(3));

        ControlPreguntas = new ControlPreguntas();

        ControlPreguntas=FindObjectOfType<ControlPreguntas>();     

	}

    private void OnTriggerEnter2D(Collider2D Collision) {

        if(Collision.CompareTag("Player")){

            PanelPreguntas.gameObject.SetActive(true);

            SetearTextoPregunta_Botones();       
        
            Time.timeScale=0;

        }

    }

    public void SetearTextoPregunta_Botones(){

        Btn1.interactable=true;
        Btn2.interactable=true;
        Btn3.interactable=true; 

        TextoRespuesta.SetText(""); 

       // string Pregunta= TraerPregunta(ResultadoEncuestaEmocion.EmocionResultante);

       //string Respuestas[]=TraerRepuestas();

        TextoPregunta.SetText(ControlPreguntas.TraerPregunta(ResultadoEncuestaEmocion.EmocionResultante));
       
        string[] respuestas=ControlPreguntas.TraerRespuestas(ResultadoEncuestaEmocion.EmocionResultante);

        
       
        Btn1.GetComponentInChildren<TextMeshProUGUI>().text=respuestas[0];
        Btn2.GetComponentInChildren<TextMeshProUGUI>().text=respuestas[1];
        Btn3.GetComponentInChildren<TextMeshProUGUI>().text=respuestas[2];


    }

    public void IsCorrect(string respuestaDeJugador)
    {
        
        //Aqui se debera verificar que lo que seleeciono el jugador es la respuesta correcta 

        //Falta comprar si la respuesta del jugador es correcta

        string RespuestaCorrecta= ControlPreguntas.RespuestaCorrectaPregunta;


        Debug.Log("respuesta Jugador: " + respuestaDeJugador);   
        Debug.Log("respuesta Correcta: " + RespuestaCorrecta);           
        
        

            Btn1.interactable=false;
            Btn2.interactable=false;
            Btn3.interactable=false;  

            TextoRespuesta.SetText("La respuesta correcta es: " + RespuestaCorrecta);
            BtnSgtePregunta.interactable=true;        

    }

    public void ObtenerRespuesta(int Buton)
    {

        if(Buton==1){
            string respuesta= Btn1.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            IsCorrect(respuesta);

           

        }

         if(Buton==2){
            string respuesta= Btn2.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            IsCorrect(respuesta);

        }

         if(Buton==3){
            string respuesta= Btn3.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            IsCorrect(respuesta);

        }
        
    }

    public void SgtePregunta()
    {
        ContadorPreguntas+=1;
        BtnSgtePregunta.interactable=false;

        if(ContadorPreguntas==2){

            BtnSgtePregunta.GetComponentInChildren<TextMeshProUGUI>().text="Jugar";
        }

        if(ContadorPreguntas<3){

            SetearTextoPregunta_Botones();

        }else{

            PanelPreguntas.gameObject.SetActive(false);
            Time.timeScale=1;

            IsKeyCollected=true;
        
            
            Key.gameObject.SetActive(true);
            clip.Play();
            GetComponent<BoxCollider2D>().enabled=false;
            GetComponent<SpriteRenderer>().enabled=false;

        }

        


    }

   

    
}
