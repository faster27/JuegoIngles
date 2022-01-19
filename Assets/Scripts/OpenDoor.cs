using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OpenDoor : MonoBehaviour
{
   
    public TMP_Text text;
    public string levelName;
    private bool InDoor=false;

    public GameObject transition;


    void OnTriggerEnter2D(Collider2D Collision){

        Scene scene = SceneManager.GetActiveScene();
        string level =scene.name;

        if(Collision.gameObject.CompareTag("Player") && FruitManager.TodasLasFrutasCogidas==true && level!="NivelBoss" && JumpDamage.IsDead==false){

            text.gameObject.SetActive(true);
            InDoor=true;
            FruitManager.TodasLasFrutasCogidas=false;

        }else if(Collision.gameObject.CompareTag("Player") && FruitManager.TodasLasFrutasCogidas==true && JumpDamage.IsDead==true){

            text.gameObject.SetActive(true);
            InDoor=true;
            FruitManager.TodasLasFrutasCogidas=false;
            
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

    public void Update(){


        if(InDoor && Input.GetKey("e")){

            transition.SetActive(true);
            Invoke("ChangeScene",1);
            

        }

    }

    void ChangeScene(){

        SceneManager.LoadScene(levelName);

    }





}
