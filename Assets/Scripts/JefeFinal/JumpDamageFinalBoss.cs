using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class JumpDamageFinalBoss : MonoBehaviour
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

    public GameObject[] Corazones;

    public ControlJefeFinal controJefe; 

   

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.CompareTag("Player")){

            clip.Play();
            collision.gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2.up*JumpForce);
            
            LosseLifeAndHit();
            CheckLifeJefeFinal();
              
            


        }

    }

     void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        level =scene.name;
        controJefe = new ControlJefeFinal();

        controJefe=FindObjectOfType<ControlJefeFinal>();

      


    }

    public void LosseLifeAndHit(){

        Lifes--;
        animator.Play("Hit");
       
        



    }


    public void CheckLifeJefeFinal(){

        if(Lifes<1)
        {
            Destroy(Corazones[0].gameObject);
            destroyParticle.SetActive(true);
            spriteRenderer.enabled=false;
           
            Invoke("EnemyDied",0.2f);

            controJefe.CambiarAudioClip();
            

        }
        else if(Lifes<2)
        {
            Destroy(Corazones[1].gameObject);
           
           

        }
        else if(Lifes<3)
        {

            Destroy(Corazones[2].gameObject);
         
            
        }
         else if(Lifes<4)
        {

            Destroy(Corazones[3].gameObject);
          
            
        }
         else if(Lifes<5)
        {

            Destroy(Corazones[4].gameObject);
       
            
        }else if(Lifes<6)
        {

            Destroy(Corazones[5].gameObject);
       
            
        }else if(Lifes<7)
        {

            Destroy(Corazones[6].gameObject);
       
            
        }else if(Lifes<8)
        {

            Destroy(Corazones[7].gameObject);
       
            
        }
    

        
    }

    public void EnemyDied(){

        Scene scene = SceneManager.GetActiveScene();
        string level =scene.name;

      

         if( level=="JefeFinal"  ){

            JumpDamage.IsDead=true;


        }

        
        Destroy(gameObject);
    }
}