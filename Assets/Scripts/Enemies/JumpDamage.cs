using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class JumpDamage : MonoBehaviour
{
    public Animator animator;

    public Collider2D collider2D;

    public SpriteRenderer spriteRenderer;

    public GameObject destroyParticle;


    public float JumpForce=2.5f;

    public int Lifes;

    string level;

    public static bool IsDead=false;

    public AudioSource clip;

    

 
   

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.CompareTag("Player")){

            clip.Play();
            collision.gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2.up*JumpForce);
            
            LosseLifeAndHit();
            CheckLife();
              
            


        }

    }

     void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        level =scene.name;
       

    


    }

    public void LosseLifeAndHit(){

        Lifes--;
        animator.Play("Hit");
       
        



    }

    public void CheckLife(){

            if(Lifes==0){

                destroyParticle.SetActive(true);
                spriteRenderer.enabled=false;
                Destroy(gameObject);

            }
               

       

        
    }


   

    
}
