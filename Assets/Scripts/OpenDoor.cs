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

    public GameObject transition;

    public GameObject PuertaImagen;
   


    void OnTriggerEnter2D(Collider2D Collision){

        Scene scene = SceneManager.GetActiveScene();
        string level =scene.name;

        if(Collision.gameObject.CompareTag("Player") && FruitManager.TodasLasFrutasCogidas==true && 
            !level.Contains("Boss") && JumpDamage.IsDead==false && KeyCollected.IsKeyCollected==true){

            text.gameObject.SetActive(true);
            InDoor=true;
            FruitManager.TodasLasFrutasCogidas=false;
            


        }else if(Collision.gameObject.CompareTag("Player") && FruitManager.TodasLasFrutasCogidas==true && JumpDamage.IsDead==true){

            text.gameObject.SetActive(true);
            InDoor=true;
            FruitManager.TodasLasFrutasCogidas=false;

            if(level=="NivelBossMundo1"){

                DoorManager.PuertaMundo1=false;
                DoorManager.PuertaMundo2=true;
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


        Scene scene2 = SceneManager.GetActiveScene();
        level2 =scene2.name;
        FruitManager.TodasLasFrutasCogidas=false;

        Debug.Log(FruitManager.TodasLasFrutasCogidas);

        

    }

   

    public void Update(){

        
        if(FruitManager.TodasLasFrutasCogidas==true && JumpDamage.IsDead==true && level2.Contains("Boss")){


            PuertaImagen.SetActive(false);
        }

        if(FruitManager.TodasLasFrutasCogidas==true && JumpDamage.IsDead==false && !level2.Contains("Boss") && KeyCollected.IsKeyCollected==true){


            PuertaImagen.SetActive(false);
           
        }

        if(InDoor && Input.GetKey("e")){

            transition.SetActive(true);
            FruitManager.TodasLasFrutasCogidas=false;
            KeyCollected.IsKeyCollected=false;
            JumpDamage.IsDead=false;
            Invoke("ChangeScene",1);
            

        }

    }

    void ChangeScene(){

        SceneManager.LoadScene(levelName);

    }





}
