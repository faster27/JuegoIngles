using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class JumpDamageFinalBoss : MonoBehaviour
{
    public Animator animator;

    public Collider2D collider2D;

    public SpriteRenderer spriteRenderer;

    public GameObject destroyParticle;

    public GameObject PanelPreguntas;

    public float JumpForce=2.5f;

    public  int Lifes;

    string level;

    public static bool IsDead=false;

    public AudioSource clip;

    public  GameObject[] Corazones;

    public ControlJefeFinal controJefe; 

    public Animator Jaula;

    //Referencia a los textos de pregunta y respuesta del panel

    public TextMeshProUGUI TextoPregunta;

    private Rigidbody2D rb;


   

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.CompareTag("Player")){

           clip.Play();
            rb=collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 posicion=new Vector2();

            posicion.x=Random.Range(-3.754858f,3.1045f);

            posicion.y=-0.2f;

            collision.transform.position=posicion;
            
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
            
            Corazones[0].gameObject.SetActive(false);
            
            destroyParticle.SetActive(true);
            spriteRenderer.enabled=false;
           
            Invoke("EnemyDied",0.2f);

            controJefe.CambiarAudioClip();
            Jaula.Play("AnimacionJaula");

            

            
            

        }
        else if(Lifes<2)
        {
             Corazones[1].gameObject.SetActive(false);
           


        }
        else if(Lifes<3)
        {

           Corazones[2].gameObject.SetActive(false);
           
            
        }
         else if(Lifes<4)
        {
            Debug.Log("quedan 3 corazones");
            Time.timeScale=0;
            PanelPreguntas.SetActive(true);
            TextoPregunta.SetText("Emoción Resultado encuesta " + ResultadoEncuestaEmocion.EmocionResultante);
            Corazones[3].gameObject.SetActive(false);

            
          
            
        }
         else if(Lifes<5)
        {

          Corazones[4].gameObject.SetActive(false);
       
            
        }else if(Lifes<6)
        {

           Corazones[5].gameObject.SetActive(false);
            
            
        }else if(Lifes<7)
        {
            Debug.Log("quedan 6 corazones");
            Time.timeScale=0;
            Corazones[6].gameObject.SetActive(false);
            PanelPreguntas.SetActive(true);
            TextoPregunta.SetText("Emoción Resultado encuesta " + ResultadoEncuestaEmocion.EmocionResultante);
            

            
       
            
        }else if(Lifes<8)
        {

            Corazones[7].gameObject.SetActive(false);
       
            
        }else if(Lifes<9)
        {

            Corazones[8].gameObject.SetActive(false);
       
            
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


    public  void IsCorrect(string respuesta)
    {

       if(respuesta!=respuesta){

            PanelPreguntas.SetActive(false);
            Time.timeScale=1;

            if(Lifes==6)
            {

                Corazones[6].gameObject.SetActive(true);
                Corazones[7].gameObject.SetActive(true);
                Corazones[8].gameObject.SetActive(true);

                Lifes=9;

            }else if(Lifes==3)
            {
                Corazones[3].gameObject.SetActive(true);
                Corazones[4].gameObject.SetActive(true);
                Corazones[5].gameObject.SetActive(true);

                Lifes=6;

            }
  

       }

       PanelPreguntas.SetActive(false);
            Time.timeScale=1;
       
        

      
    }

    
}