using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OpenDoor : MonoBehaviour
{


    //funciona lo que pasa es que cuando se cogen todas las frutas las pertas e quedan abiertas en todos los niveles 
   
    public TMP_Text text;
    public string levelName;
    private bool InDoor=false;
    string level2;

    int SenalPuerta=0;

    public GameObject transition;

    public GameObject PuertaImagen;

    public  GameObject PanelPreguntasPuerta;

    private KeyCollected ColeccionLlave; 

    public Button Panel2Btn1;
    public Button Panel2Btn2;
    public Button Panel2Btn3;
    public Button BtnJugar;
    

    public TextMeshProUGUI TextoPregunta;
    public TextMeshProUGUI TextoRespuesta;

    private ControlPreguntas ControlPreguntas; 

   
    void Start(){

        ColeccionLlave = new KeyCollected();

        ColeccionLlave=FindObjectOfType<KeyCollected>();

        Scene scene2 = SceneManager.GetActiveScene();
        level2 =scene2.name;

        FruitManager.TodasLasFrutasCogidas=false;

        Button Panel2Btn11 = Panel2Btn1.GetComponent<Button>();
		Panel2Btn11.onClick.AddListener(() =>ObtenerRespuesta(1));

        Button Panel2Btn22 = Panel2Btn2.GetComponent<Button>();
		Panel2Btn22.onClick.AddListener(() => ObtenerRespuesta(2));

        Button Panel2Btn33 = Panel2Btn3.GetComponent<Button>();
		Panel2Btn33.onClick.AddListener(() => ObtenerRespuesta(3));

        ControlPreguntas = new ControlPreguntas();

        ControlPreguntas=FindObjectOfType<ControlPreguntas>();
       

    }

    public void Update(){

        if(FruitManager.TodasLasFrutasCogidas==true && JumpDamage.IsDead==true && level2.Contains("Boss")){


            PuertaImagen.SetActive(false);
        }

        if(InDoor && Input.GetKey("e") && !PanelPreguntasPuerta.activeSelf){

            transition.SetActive(true);
            FruitManager.TodasLasFrutasCogidas=false;
            KeyCollected.IsKeyCollected=false;
            JumpDamage.IsDead=false;
            Invoke("ChangeScene",4);
            

        }

    }

    void OnTriggerEnter2D(Collider2D Collision){

        Scene scene = SceneManager.GetActiveScene();
        string level =scene.name;
        
        if(Collision.gameObject.CompareTag("Player") && FruitManager.TodasLasFrutasCogidas==true && 
            !level.Contains("Boss") && JumpDamage.IsDead==false && KeyCollected.IsKeyCollected==true && SenalPuerta==0){

            PuertaImagen.SetActive(false);
            text.gameObject.SetActive(true);
            PanelPreguntasPuerta.SetActive(true);
            FruitManager.TodasLasFrutasCogidas=false;
            Time.timeScale=0;
            InDoor=true;
            SenalPuerta=1;

            

            SetearTextoPregunta_Botones();


        }
        
        else if(Collision.gameObject.CompareTag("Player") && FruitManager.TodasLasFrutasCogidas==true && 
            !level.Contains("Boss") && JumpDamage.IsDead==false && KeyCollected.IsKeyCollected==true && SenalPuerta!=0){
                
                text.gameObject.SetActive(true);
                FruitManager.TodasLasFrutasCogidas=false;
                InDoor=true;



        }
        
        
        
        else if(Collision.gameObject.CompareTag("Player") && FruitManager.TodasLasFrutasCogidas==true && JumpDamage.IsDead==true){

            text.gameObject.SetActive(true);
            PuertaImagen.SetActive(true);
            
            InDoor=true;
            FruitManager.TodasLasFrutasCogidas=false;

            if(level=="NivelBossMundo1"){

                DoorManager.PuertaMundo1=false;
                DoorManager.PuertaMundo2=true;
            }

            if(level=="NivelBossMundo2"){

                DoorManager.PuertaMundo1=false;
                DoorManager.PuertaMundo2=false;
                DoorManager.PuertaMundo3=true;
            }

            if(level=="NivelBossMundo3"){

                DoorManager.PuertaMundo1=false;
                DoorManager.PuertaMundo2=false;
                DoorManager.PuertaMundo3=true;
            }

            if(level=="JefeFinal"){

                DoorManager.PuertaMundo1=true;
                DoorManager.PuertaMundo2=false;
                DoorManager.PuertaMundo3=false;
             
            }

        }    

        
              
        if( level=="Mundos" && Collision.gameObject.CompareTag("Player") ){


                text.gameObject.SetActive(true);
                InDoor=true;
             


        }

         


    }

    public void SetearTextoPregunta_Botones(){

       // string Pregunta= TraerPregunta(ResultadoEncuestaEmocion.EmocionResultante);

       //string Respuestas[]=TraerRepuestas();

        TextoPregunta.SetText(ControlPreguntas.TraerPregunta(ResultadoEncuestaEmocion.EmocionResultante));

       
        string[] respuestas=ControlPreguntas.TraerRespuestas(ResultadoEncuestaEmocion.EmocionResultante);

        
       
        Panel2Btn1.GetComponentInChildren<TextMeshProUGUI>().text=respuestas[0];
        Panel2Btn2.GetComponentInChildren<TextMeshProUGUI>().text=respuestas[1];
        Panel2Btn3.GetComponentInChildren<TextMeshProUGUI>().text=respuestas[2];


    }

     public void IsCorrect(string respuestaDeJugador)
    {
        
        //Aqui se debera verificar que lo que seleeciono el jugador es la respuesta correcta 

        string RespuestaCorrecta= ControlPreguntas.RespuestaCorrectaPregunta;


        Debug.Log("respuesta Jugador: " + respuestaDeJugador);   
        Debug.Log("respuesta Correcta: " + RespuestaCorrecta);           
        
        

        Panel2Btn1.interactable=false;
        Panel2Btn2.interactable=false;
        Panel2Btn3.interactable=false;  

        if(respuestaDeJugador != RespuestaCorrecta){

            TextoRespuesta.SetText("La respuesta correcta es: " + RespuestaCorrecta);

        }else{

                TextoRespuesta.SetText("La respuesta es correcta");

        }

        

        BtnJugar.interactable=true;
                
    }

    public void ObtenerRespuesta(int Buton)
    {

        if(Buton==1){
            string respuesta= Panel2Btn1.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            IsCorrect(respuesta);

           

        }

         if(Buton==2){
            string respuesta= Panel2Btn2.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            IsCorrect(respuesta);

        }

         if(Buton==3){
            string respuesta= Panel2Btn3.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            IsCorrect(respuesta);

        }

        

     

        
        
    }

    public void SeguirJugar()
    {

        PanelPreguntasPuerta.gameObject.SetActive(false);
        Time.timeScale=1;


    }

    

           
    void OnTriggerExit2D(Collider2D Collision){

        text.gameObject.SetActive(false);
        InDoor=false;
                
    }

       
    void ChangeScene(){

        SceneManager.LoadScene(levelName);

    }





}


