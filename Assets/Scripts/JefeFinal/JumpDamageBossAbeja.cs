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

    public GameObject SignosPreguntas;

    
    public static bool SignoPreguntaIsActive=false;

    public GameObject Explosion;

  

    public GameObject Hechicero;

    public GameObject Signo1;
    public GameObject Signo2;
    public GameObject Signo3;
    public GameObject Signo4;
    public GameObject Signo5;
    public GameObject Signo6;
    
    public GameObject posInicial1;
    public GameObject posInicial2;
    public GameObject posInicial3;
    public GameObject posInicial4;
    public GameObject posInicial5;
    public GameObject posInicial6;

    //Referencia a los textos de pregunta y respuesta del panel

    public TextMeshProUGUI TextoPregunta;

    private Rigidbody2D rb;

    private ControlPreguntasJefeFinal ControlPreguntas; 
    public GameObject[] ControlMovimientosSignos;
   

    public GameObject TeleportAnimation;
    public GameObject Rana;
    public GameObject TituloAunNoTermina;

   

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

      //  ControlMovimientosSignos = new MovimientoSigno();

       // ControlMovimientosSignos=FindObjectOfType<MovimientoSigno>();

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
           
            
            TituloAunNoTermina.SetActive(true);
            Invoke("AnimacionExplosion",5.0f);
            
           

            gameObject.SetActive(false);

        }
        else if(Lifes<2)
        {
            Corazones[1].gameObject.SetActive(false);
            gameObject.SetActive(false);
            SignosPreguntas.SetActive(true);

            Invoke("DesactivarSignosPregunta",5f);
            ControlMovimientosSignos[0].GetComponent<MovimientoSigno>().AnadirFuerza();
            ControlMovimientosSignos[1].GetComponent<MovimientoSigno>().AnadirFuerza();
            ControlMovimientosSignos[2].GetComponent<MovimientoSigno>().AnadirFuerza();
            ControlMovimientosSignos[3].GetComponent<MovimientoSigno>().AnadirFuerza();
            ControlMovimientosSignos[4].GetComponent<MovimientoSigno>().AnadirFuerza();
            ControlMovimientosSignos[5].GetComponent<MovimientoSigno>().AnadirFuerza();
           


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

            gameObject.SetActive(false);
            SignosPreguntas.SetActive(true);
            
            Invoke("DesactivarSignosPregunta",5f);
           // ControlMovimientosSignos.AnadirFuerza();
            ControlMovimientosSignos[0].GetComponent<MovimientoSigno>().AnadirFuerza();
            ControlMovimientosSignos[1].GetComponent<MovimientoSigno>().AnadirFuerza();
            ControlMovimientosSignos[2].GetComponent<MovimientoSigno>().AnadirFuerza();
            ControlMovimientosSignos[3].GetComponent<MovimientoSigno>().AnadirFuerza();
            ControlMovimientosSignos[4].GetComponent<MovimientoSigno>().AnadirFuerza();
            ControlMovimientosSignos[5].GetComponent<MovimientoSigno>().AnadirFuerza();
       
            
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
           
       
            gameObject.SetActive(false);
            SignosPreguntas.SetActive(true);
            


            Invoke("DesactivarSignosPregunta",5f);
           // ControlMovimientosSignos.AnadirFuerza();
           //ControlMovimientosSignos[0].GetComponent<MovimientoSigno>().AnadirFuerza();
           // ControlMovimientosSignos[1].GetComponent<MovimientoSigno>().AnadirFuerza();
           // ControlMovimientosSignos[2].GetComponent<MovimientoSigno>().AnadirFuerza();
           // ControlMovimientosSignos[3].GetComponent<MovimientoSigno>().AnadirFuerza();
           // ControlMovimientosSignos[4].GetComponent<MovimientoSigno>().AnadirFuerza();
           // ControlMovimientosSignos[5].GetComponent<MovimientoSigno>().AnadirFuerza();
       
            
        }else if(Lifes<9)
        {

            Corazones[8].gameObject.SetActive(false);
       
            
        }
    

        
    }

    public void DesactivarSignosPregunta(){
       
        Signo1.transform.position=posInicial1.transform.position;
        Signo2.transform.position=posInicial2.transform.position;
        Signo3.transform.position=posInicial3.transform.position;
        Signo4.transform.position=posInicial4.transform.position;
        Signo5.transform.position=posInicial5.transform.position;
        Signo6.transform.position=posInicial6.transform.position;
       // ControlMovimientosSignos.AnadirFuerza();
        
        SignosPreguntas.SetActive(false);

        if(!PanelPreguntas.activeSelf){

            gameObject.SetActive(true);

        }
        
        
    }

    public void AnimacionExplosion(){

        
        Explosion.SetActive(true);
        TituloAunNoTermina.SetActive(false);
        
        Invoke("Mago",0.05f);
       

    }

    public void Mago(){

       
        Hechicero.SetActive(true); 

    }

    public void ActivarAbeja(){

        Debug.Log(SignoPreguntaIsActive);

        if(SignoPreguntaIsActive){

            Debug.Log("estoy aajajajaja");
            gameObject.SetActive(true);
            SignoPreguntaIsActive=false;
        }
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
