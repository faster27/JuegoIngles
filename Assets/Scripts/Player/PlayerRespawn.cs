using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerRespawn : MonoBehaviour{


 
    public Animator animator;
    public GameObject[] Corazones;
    private int Vida;


    // Start is called before the first frame update
    void Start()
    {
        Vida=Corazones.Length;
    }

    private void VerificarCorazones()
    {
        
        if(Vida<1)
        {
            Destroy(Corazones[0].gameObject);
            animator.Play("Hit");
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else if(Vida<2)
        {
            Destroy(Corazones[1].gameObject);
           animator.Play("Hit");
           

        }
        else if(Vida<3)
        {

            Destroy(Corazones[2].gameObject);
            animator.Play("Hit");
            
        }
        
        

    }

   public void PlayerDamaged()
   {
        
        Vida--;
        VerificarCorazones();
       
       

   }


}
