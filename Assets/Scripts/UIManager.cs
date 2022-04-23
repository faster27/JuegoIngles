using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;



public class UIManager : MonoBehaviour
{
    public GameObject TransicionCambioEscena;
    public AudioSource clip;
    public GameObject optionsPanel;
   
    public GameObject PanelAnimacion;

    private string level;
    

   // public string SgteEscena;

    public GameObject Personaje;

    public GameObject Camara;

    public GameObject PanelTotal;

    public GameObject PanelPreguntasLlave;
    public GameObject PanelPreguntasPuerta;


   


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        level =scene.name;

     


        if ( (level.Contains("Nivel")  || level.Contains("Jefe")) && !level.Contains("Boss") )
        {

             Personaje.SetActive(false);

            


        }

        Invoke("DesactivarPanel",3f);

       
       
        
        
    }

    void DesactivarPanel(){

        PanelAnimacion.SetActive(false);

    }

    void Update(){

        if(Input.GetKey(KeyCode.Escape ) && !PanelTotal.activeSelf && !PanelPreguntasLlave.activeSelf && !PanelPreguntasPuerta.activeSelf && !PanelAnimacion.activeSelf && !TransicionCambioEscena.activeSelf )
        {  
         
           OptionsPanel();
           
        }

        
        
      

       

    }

    public void PanelEncuesta()
    {
        if(!level.Contains("Boss") && !level.Contains("Mundos") ){

            Time.timeScale=0;

            PanelAnimacion.SetActive(false);

         
        }

    }

    

    public void ActivarJuego()
    {
        Time.timeScale=1;

    }

    public void OptionsPanel()
    {
        Time.timeScale=0;
        
        optionsPanel.SetActive(true);
       
    
    }

   
    

    public void Return()
    {
        Time.timeScale=1;
        
        optionsPanel.SetActive(false);
       


    }


    public void ActivarPersonaje()
    {
            Personaje.SetActive(true);

             if(level=="Nivel2Mundo2" || level=="Nivel4Mundo2" || level=="Nivel2Mundo3" || level=="Nivel3Mundo3"
                || level=="Nivel4Mundo3"){

                Camara.SetActive(false);

             }
    }

    public void MenuPrincipal()
    {
       
        
        
        Time.timeScale=1;
        SceneManager.LoadScene("Mundos");
        

    }

    public void SalirDelJuego()
    {

        Application.Quit();

    }

    public void PlaySoundButton(){

        clip.Play();

    }

    public void CargarEscena()
    {
        TransicionCambioEscena.SetActive(true);
        Invoke("ChangeScene",1);
       
        
        

    }

    void ChangeScene(){
        
        SceneManager.LoadScene("Mundos");

    }

   // public void PasarALaEscena(){
        
    //    SceneManager.LoadScene(SgteEscena);

   // }

    void ChangeSceneIntro(){
        
        SceneManager.LoadScene("ScenaIntro");

    }

    public void CargarEscenaIntro()
    {
        
        Invoke("ChangeSceneIntro",4);

    }

}
