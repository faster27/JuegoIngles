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

    public int Lifes=2;

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

    public void LosseLifeAndHit(){

        Lifes--;
        animator.Play("Hit");
       
        



    }

    public void CheckLife(){

        if(Lifes==0){

            destroyParticle.SetActive(true);
            spriteRenderer.enabled=false;
            Invoke("EnemyDied",0.2f);


        }
    }

    public void EnemyDied(){

        Scene scene = SceneManager.GetActiveScene();
        string level =scene.name;

        if( level=="NivelBossMundo1"  ){

            IsDead=true;


        }

         if( level=="NivelBossMundo2"  ){

            IsDead=true;


        }

         if( level=="NivelBossMundo3"  ){

            IsDead=true;


        }

        
        Destroy(gameObject);
    }
}
