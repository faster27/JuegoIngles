using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using UnityEngine.SceneManagement;
using TMPro;

public class TextoEscenaIntro : MonoBehaviour
{
    //Historia del Intro
    
    string frase = "En medio de un bosque existía un pequeño reino llamado Cortor,\n"+
                    "en el cual habitaba la princesa Freyja, un día de repente todo se oscureció,\n"+
                    "en medio de la espesa niebla el hechicero supremo Khorne apareció,\n"+
                    "capturando a la princesa y llevándola a una lejana torre donde la encerró,\n"+
                    "pero antes de irse hizo que todos olvidaran\n"+
                    "cómo hablar inglés  dejando un mensaje de polvo tras desaparecer.";
    
    string frase2="\"A la princesa deberán salvar si su idioma quieren recuperar,\n"+
                    "y para ello deberán enviar a su mejor guerrero, el cual los retos deberá superar.\"";

    
    //Historia antes del mundo 3

    string frase5= "Guerrero has tenido un largo viaje hasta aquí,\n"+
                    "las canciones hablan de que has atravesado selvas, pantanos e incluso desiertos para rescatar a la princesa,\n"+
                    "estás a un solo paso de hacerlo, pero primero debes entrar al castillo y llegar hasta la torre.\n"+
                    "Dentro encontrarás criaturas nunca antes vistas, pero toda tu aldea te apoya,\n"+
                    "las derrotarás con tu sabiduría  y traerás gloria y felicidad a tu pueblo, adelante.";
    
    
    //Historia antes de pelear con el jefe final

    string frase3= "Guerrero has pasado pruebas que ningún otro ser viviente ha podido superar y has llegado hasta aquí,\n"+
                    "pero aún falta la prueba más importante, derrotar al hechicero supremo,\n"+
                    "el cual tiene secuestrada a tu princesa y a tu pueblo sin poder hablar inglés\n"+
                    "juntos lo derrotaremos ¡AU AU AU!.";
    
    //Historia despues de la pelea con el jefe

    string frase4= "Felicitaciones guerrero, lo has logrado, has liberado a tu princesa\n"+
                    "y le has devuelto a tu pueblo el poder de hablar inglés\n"+
                    "ve y disfruta tu victoria con tu gente.";
    
    
    
    public TMP_Text texto;

    string fraseConvertida;
    string frase2Convertida;
    string frase3Convertida;
    string frase4Convertida;
    string frase5Convertida;

    public float VelocidadTexto=0.1f;

    public GameObject PanelAnimation;

    public AudioSource clip;

    string level;

    

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        level =scene.name;

        fraseConvertida=ConvertirFrase(frase);
        frase2Convertida=ConvertirFrase(frase2);
        frase3Convertida=ConvertirFrase(frase3);
        frase4Convertida=ConvertirFrase(frase4);
        frase5Convertida=ConvertirFrase(frase5);
        StartCoroutine(Reloj());
    }

    void Update(){

        
        if(Input.GetKey("e")){

           VelocidadTexto=0.01f;
            

        }
    }


    

    IEnumerator Reloj()
    {

        if(level=="ScenaIntro"){

            foreach (char caracter in fraseConvertida)
            {
                texto.text = texto.text + caracter;
                yield return new WaitForSeconds(VelocidadTexto);
            }

            yield return new WaitForSeconds(3f);
            BorrarTexto();
        
            foreach (char caracter in frase2Convertida)
            {
                texto.text = texto.text + caracter;
                yield return new WaitForSeconds(VelocidadTexto);
            }
            clip.Stop();
            yield return new WaitForSeconds(3f);
            PanelAnimation.SetActive(true);
            Invoke("ChangeScene",4);

        }


        if(level=="AntesDelJefe"){

            foreach (char caracter in frase3Convertida)
            {
                texto.text = texto.text + caracter;
                yield return new WaitForSeconds(VelocidadTexto);
            }           
            clip.Stop();
            yield return new WaitForSeconds(3f);
            PanelAnimation.SetActive(true);
            Invoke("ChangeScene",4);

        }

        if(level=="EscenaFinal"){

            foreach (char caracter in frase4Convertida)
            {
                texto.text = texto.text + caracter;
                yield return new WaitForSeconds(VelocidadTexto);
            }
            clip.Stop();
            yield return new WaitForSeconds(3f);
            PanelAnimation.SetActive(true);
            Invoke("ChangeScene",4);

        }

         if(level=="AntesDelMundo3"){

            foreach (char caracter in frase5Convertida)
            {
                texto.text = texto.text + caracter;
                yield return new WaitForSeconds(VelocidadTexto);
            }
            clip.Stop();
            yield return new WaitForSeconds(3f);
            PanelAnimation.SetActive(true);
            Invoke("ChangeScene",4);

        }

       


    }

    public void BorrarTexto(){

        texto.text=" ";
    }

    public string ConvertirFrase(string fraseAConvertir){

        string fraseFinal;

        byte[] bytes = Encoding.Default.GetBytes(fraseAConvertir);
        fraseFinal = Encoding.UTF8.GetString(bytes);

        return fraseFinal;
        
    }

    void ChangeScene(){
        
        if(level=="ScenaIntro")
        {
            SceneManager.LoadScene("Mundos");
        }

        if(level=="AntesDelJefe"){

            SceneManager.LoadScene("JefeFinal");

        }

        if(level=="EscenaFinal")
        {

            SceneManager.LoadScene("MenuInicial");

        }

        if(level=="AntesDelMundo3")
        {

            SceneManager.LoadScene("Nivel1Mundo3");

        }

        

    }
}
