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



    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        level =scene.name;

        Invoke("PanelEncuesta",2.5f);
       
        
        
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


    public void OtherOptions()
    {

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

    void ChangeSceneIntro(){
        
        SceneManager.LoadScene("ScenaIntro");

    }

    public void CargarEscenaIntro()
    {
        
        Invoke("ChangeSceneIntro",4);

    }

}
