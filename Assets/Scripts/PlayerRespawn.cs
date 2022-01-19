using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerRespawn : MonoBehaviour{


 
public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void PlayerDamaged(){

       animator.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

   }
}
