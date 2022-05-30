using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class UIManagerMenuPrincipal : MonoBehaviour
{
    public GameObject TransicionCambioEscena;
    public AudioSource clip;
    public GameObject optionsPanel;

    
    public TextMeshProUGUI NombreSlot1;
    public TextMeshProUGUI NombreSlot2;
    public TextMeshProUGUI NombreSlot3;

    public Button BtnSlot1;
    public Button BtnSlot2;
    public Button BtnSlot3;
   

    private string level;



    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        level =scene.name;
        string Slot1=PlayerPrefs.GetString("NombreSlot1");
        string Slot2=PlayerPrefs.GetString("NombreSlot2");
        string Slot3=PlayerPrefs.GetString("NombreSlot3");

        string NombreNivelBtn1=PlayerPrefs.GetString("NivelGuardadoBoton1");
        string NombreNivelBtn2=PlayerPrefs.GetString("NivelGuardadoBoton2");
        string NombreNivelBtn3=PlayerPrefs.GetString("NivelGuardadoBoton3");

        if(NombreNivelBtn1 != ""){

            NombreSlot1.SetText(Slot1);
        }else{

            BtnSlot1.interactable=false;
        }

        if(NombreNivelBtn2 != ""){

            NombreSlot2.SetText(Slot2);
        }else{

            BtnSlot2.interactable=false;
        }

        if(NombreNivelBtn2 != ""){

            NombreSlot2.SetText(Slot2);
        }else{

            BtnSlot3.interactable=false;
        }

        
       
        
        
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


    public void CargarEscenaBoton1(){

        string EscenaACargar=PlayerPrefs.GetString("NivelGuardadoBoton1");
        SceneManager.LoadScene(EscenaACargar);

    }

    public void CargarEscenaBoton2(){

        string EscenaACargar=PlayerPrefs.GetString("NivelGuardadoBoton2");
        SceneManager.LoadScene(EscenaACargar);

    }

    public void CargarEscenaBoton3(){

        string EscenaACargar=PlayerPrefs.GetString("NivelGuardadoBoton3");
        SceneManager.LoadScene(EscenaACargar);

    }
}
