using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class UIManager : MonoBehaviour
{
    public GameObject transition;
    public AudioSource clip;
    public GameObject optionsPanel;

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
        transition.SetActive(true);
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
