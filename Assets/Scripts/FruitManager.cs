using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    
    
    public Text totalFruits;
    public Text FruitsCollected;

    private int totalFruitsInLevel;

    public static bool TodasLasFrutasCogidas=false;

    private void Start(){

        totalFruitsInLevel=transform.childCount;
        TodasLasFrutasCogidas=false;


    }

    private void Update(){

        AllFruitsCollected();
        totalFruits.text=totalFruitsInLevel.ToString();
        FruitsCollected.text=transform.childCount.ToString();

    }

    public void AllFruitsCollected(){

        if(transform.childCount==0){


       
            TodasLasFrutasCogidas=true;

            
            
           
        }



    }


    void ChangeScene(){


         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }


}
