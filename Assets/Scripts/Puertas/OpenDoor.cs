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

    public TextMeshProUGUI TextoPregunta;
   


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

            //Aqui se debe llamar la funcion la cual tare las preguntas de la bD par setear los botones

             TextoPregunta.SetText("Emoción Resultado encuesta " + ResultadoEncuestaEmocion.EmocionResultante);


        }else if(Collision.gameObject.CompareTag("Player") && FruitManager.TodasLasFrutasCogidas==true && 
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

             if(level=="JefeFinal"){

                DoorManager.PuertaMundo1=true;
                DoorManager.PuertaMundo2=false;
                DoorManager.PuertaMundo3=false;
             if(level=="NivelBossMundo3"){

                DoorManager.PuertaMundo1=false;
                DoorManager.PuertaMundo2=false;
                DoorManager.PuertaMundo3=true;
            }
            
            
        }

        

        if( level=="Mundos" && Collision.gameObject.CompareTag("Player") ){


                text.gameObject.SetActive(true);
                InDoor=true;
             


        }

         


    }

    void OnTriggerExit2D(Collider2D Collision){

        text.gameObject.SetActive(false);
        InDoor=false;
        

        
    }

    void Start(){

        ColeccionLlave = new KeyCollected();

        ColeccionLlave=FindObjectOfType<KeyCollected>();
        Scene scene2 = SceneManager.GetActiveScene();
        level2 =scene2.name;
        FruitManager.TodasLasFrutasCogidas=false;

        Button Panel2Btn11 = Panel2Btn1.GetComponent<Button>();
		Panel2Btn11.onClick.AddListener(() =>ColeccionLlave.ObtenerRespuesta(1));

        Button Panel2Btn22 = Panel2Btn2.GetComponent<Button>();
		Panel2Btn22.onClick.AddListener(() => ColeccionLlave.ObtenerRespuesta(2));

        Button Panel2Btn33 = Panel2Btn3.GetComponent<Button>();
		Panel2Btn33.onClick.AddListener(() => ColeccionLlave.ObtenerRespuesta(3));
       

        


    }

   

    public void Update(){

        if(FruitManager.TodasLasFrutasCogidas==true && JumpDamage.IsDead==true && level2.Contains("Boss")){


            PuertaImagen.SetActive(false);
        }

        if(InDoor && Input.GetKey("e")){

            transition.SetActive(true);
            FruitManager.TodasLasFrutasCogidas=false;
            KeyCollected.IsKeyCollected=false;
            JumpDamage.IsDead=false;
            Invoke("ChangeScene",4);
            

        }

    }

    void ChangeScene(){

        SceneManager.LoadScene(levelName);

    }





}
