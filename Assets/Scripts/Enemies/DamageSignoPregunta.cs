using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSignoPregunta : MonoBehaviour
{
    
    public GameObject PanelPreguntas;
    private ControlPreguntasJefeFinal ControlPreguntas; 

   

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

    public GameObject SignosDePreguntas;

    public GameObject Abeja;

    void Start()
    {
       
        

        ControlPreguntas = new ControlPreguntasJefeFinal();

        ControlPreguntas=FindObjectOfType<ControlPreguntasJefeFinal>();

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player")){

            PanelPreguntas.SetActive(true);
            ControlPreguntas.SetearTextoPregunta_Botones();

            
            JumpDamageBossAbeja.SignoPreguntaIsActive=true;
            
            Signo1.transform.position=posInicial1.transform.position;
            Signo2.transform.position=posInicial2.transform.position;
            Signo3.transform.position=posInicial3.transform.position;
            Signo4.transform.position=posInicial4.transform.position;
            Signo5.transform.position=posInicial5.transform.position;
            Signo6.transform.position=posInicial6.transform.position;

            

            SignosDePreguntas.SetActive(false);

            ControlPreguntasJefeFinal.SignoPreguntaMeToco=true;

            //aqui se debe mirar pra que una vez se desactiven los signos de pregunta e vueven a la posicion
            //inicial y asi aparezcan bien cuando vulvan a ser activados

            
           // Debug.Log(bandera);
           
            
        }

    }

    
   
}
