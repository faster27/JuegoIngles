using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyCollected : MonoBehaviour
{
    public AudioSource clip;
    public GameObject Key;
    public GameObject PanelPreguntas;
    public static bool IsKeyCollected=false;


    public Button Btn1;
    public Button Btn2;
    public Button Btn3;

    public GameObject Llave;


    public GameObject PanelPreguntasPuerta;

   void Start () {
		Button Btn11 = Btn1.GetComponent<Button>();
		Btn11.onClick.AddListener(() => ObtenerRespuesta(1));

        Button Btn22 = Btn2.GetComponent<Button>();
		Btn22.onClick.AddListener(() => ObtenerRespuesta(2));

        Button Btn33 = Btn3.GetComponent<Button>();
		Btn33.onClick.AddListener(() => ObtenerRespuesta(3));

        //Aqui se debe traer las preguntas cando se coja la llave
        
        

	}

    
    
    private void OnTriggerEnter2D(Collider2D Collision) {

        if(Collision.CompareTag("Player")){

            PanelPreguntas.gameObject.SetActive(true);
        
            Time.timeScale=0;

            
            //Aqui se debe llamar la funcion la cual tare las preguntas de la bD par setear los botones

        }

    }

    public void IsCorrect(string respuesta)
    {
        
        //Aqui se debera verificar que lo que seleeciono el jugador es la respuesta correcta 


        PanelPreguntas.gameObject.SetActive(false);
        PanelPreguntasPuerta.gameObject.SetActive(false);
        Time.timeScale=1;

        IsKeyCollected=true;
        
            
        Key.gameObject.SetActive(true);
        clip.Play();
        GetComponent<BoxCollider2D>().enabled=false;
        GetComponent<SpriteRenderer>().enabled=false;

        
    }

    public void ObtenerRespuesta(int Buton)
    {

        if(Buton==1){
            string respuesta= Btn1.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            IsCorrect(respuesta);

           

        }

         if(Buton==2){
            string respuesta= Btn2.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            IsCorrect(respuesta);

        }

         if(Buton==3){
            string respuesta= Btn3.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            IsCorrect(respuesta);

        }

         if(Buton==4){
            
            Debug.Log("hola");
            

        }

     

        
        
    }

    public void SiguientePregunta(){

        Debug.Log("ahola");

        //Aqui s deben tarer la demas preguntas para setear los botones y hacer el cambio de pregunta
    }

    
}
