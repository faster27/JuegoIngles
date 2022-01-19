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
    string frase = "En medio de un bosque existía un pequeño pueblo con un castillo,\n en el cual habitaba una princesa, un dia de repente todo se oscureció, \n en medio de la espesa niebla el hechicero supremo apareció, capturando a la princesa \n y llevándola a una lejana torre donde la encerró, pero antes de irse hizo que todos olvidaran \n cómo hablar inglés  dejando un mensaje de polvo tras desaparecer.";
    string frase2="A la princesa deberán salvar si su idioma quieren recuperar,\n y para ello deberán enviar a su mejor guerrero, quien los retos deberá superar.";

    public TMP_Text texto;

    string fraseConvertida;
    string frase2Convertida;

    public GameObject PanelAnimation;

    public AudioSource clip;

    

    // Start is called before the first frame update
    void Start()
    {

        fraseConvertida=ConvertirFrase(frase);
        frase2Convertida=ConvertirFrase(frase2);
        StartCoroutine(Reloj());
    }


    

    IEnumerator Reloj()
    {

        

        foreach (char caracter in fraseConvertida)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(3f);
        BorrarTexto();
       
        foreach (char caracter in frase2)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
        clip.Stop();
        yield return new WaitForSeconds(3f);
        PanelAnimation.SetActive(true);
        Invoke("ChangeScene",4);


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
        
        SceneManager.LoadScene("Mundos");

    }
}
