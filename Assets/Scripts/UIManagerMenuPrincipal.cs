using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIManagerMenuPrincipal : MonoBehaviour
{
    public GameObject TransicionCambioEscena;
    public AudioSource clip;
    public GameObject optionsPanel;

    
   
   

    private string level;



    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        level =scene.name;
       
        
       
        
        
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
