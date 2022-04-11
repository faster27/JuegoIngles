using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class JumpDamageBossAbeja : MonoBehaviour
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
    public AudioSource Teleport;
    

    public  GameObject[] Corazones;

    public GameObject Explosion;

  

    public GameObject Hechicero;

    //Referencia a los textos de pregunta y respuesta del panel

    public TextMeshProUGUI TextoPregunta;

    private Rigidbody2D rb;

    private ControlPreguntasJefeFinal ControlPreguntas; 

    public GameObject TeleportAnimation;
    public GameObject Rana;

   

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.CompareTag("Player")){

            clip.Play();
            Teleport.Play();


            //Aqui se leda una nueva coordenada aleatoria al jugador para generar el efecto de teletransporte
            rb=collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 posicion=new Vector2();
            Rana.SetActive(false);
            TeleportAnimation.SetActive(true);
            posicion.x=Random.Range(-3.754858f,3.1045f);
            posicion.y=-0.2f;
            collision.transform.position=posicion;
            Rana.SetActive(true);
            
            LosseLifeAndHit();
            CheckLifeJefeFinal();
              
            


        }

    }
    

     void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        level =scene.name;

        ControlPreguntas = new ControlPreguntasJefeFinal();

        ControlPreguntas=FindObjectOfType<ControlPreguntasJefeFinal>();

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
           
            
            
            Invoke("AnimacionExplosion",5.0f);
            
           

            gameObject.SetActive(false);

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

            ControlPreguntas.SetearTextoPregunta_Botones();

           // TextoPregunta.SetText("Emoción Resultado encuesta " + ResultadoEncuestaEmocion.EmocionResultante);
            
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
            //TextoPregunta.SetText("Emoción Resultado encuesta " + ResultadoEncuestaEmocion.EmocionResultante);
            ControlPreguntas.SetearTextoPregunta_Botones();

            
       
            
        }else if(Lifes<8)
        {

            Corazones[7].gameObject.SetActive(false);
       
            
        }else if(Lifes<9)
        {

            Corazones[8].gameObject.SetActive(false);
       
            
        }
    

        
    }

    public void AnimacionExplosion(){

        
        Explosion.SetActive(true);
        
        Invoke("Mago",0.05f);
       

    }

    public void Mago(){

       
        Hechicero.SetActive(true); 

    }

    public  void RegenerarCorazones()
    {
   
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

}
