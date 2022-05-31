using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SistemaDeGuardado : MonoBehaviour
{
    
    public Button BotonContinuarCampana;

    public Button BtnCerrarPanelSlots;

    public TextMeshProUGUI NombreSlot1;
    public TextMeshProUGUI NombreSlot2;
    public TextMeshProUGUI NombreSlot3;

    public GameObject TituloGuardadoConExito;

    public TMP_InputField NombrePartida;

    public GameObject PanelPedirNombre;
    public GameObject PanelGuardar;

    string NivelGuardar;
    
    int SeñalBotonOprimido=0;
    
    // Start is called before the first frame update
    

    void Start()
    {
        Scene scene2 = SceneManager.GetActiveScene();
        NivelGuardar =scene2.name;

        string Slot1=PlayerPrefs.GetString("NombreSlot1");
        string Slot2=PlayerPrefs.GetString("NombreSlot2");
        string Slot3=PlayerPrefs.GetString("NombreSlot3");

        if(Slot1 != ""){

            NombreSlot1.SetText(Slot1);
        }
        if(Slot2 != ""){

            NombreSlot2.SetText(Slot2);
        }
        if(Slot3 != ""){

            NombreSlot3.SetText(Slot3);
        }

        string NombreNivel=PlayerPrefs.GetString("NivelGuardadoBoton1");
        string NombreNivel2=PlayerPrefs.GetString("NivelGuardadoBoton2");
        string NombreNivel3=PlayerPrefs.GetString("NivelGuardadoBoton3");

        if(NivelGuardar=="MenuInicial" && (NombreNivel!="" || NombreNivel2!="" || NombreNivel3!="")){

            BotonContinuarCampana.interactable=true;
        }


    }

    public void GuardarBoton1(){

        SeñalBotonOprimido=1;

        string NivelGuardadoBoton1 = PlayerPrefs.GetString("NivelGuardadoBoton1");

        if(NivelGuardadoBoton1 != ""){

            PlayerPrefs.SetString("NivelGuardadoBoton1",NivelGuardar);
           // PanelGuardar.SetActive(false);
            TituloGuardadoConExito.SetActive(true);
        }else{
            PanelPedirNombre.SetActive(true);
            BtnCerrarPanelSlots.interactable=false;
        }
    }

    public void GuardarBoton2(){

        SeñalBotonOprimido=2;

        string NivelGuardadoBoton2 = PlayerPrefs.GetString("NivelGuardadoBoton2");

        if(NivelGuardadoBoton2 != ""){
            
            PlayerPrefs.SetString("NivelGuardadoBoton2",NivelGuardar);
            //PanelGuardar.SetActive(false);
            TituloGuardadoConExito.SetActive(true);
        }else{
            PanelPedirNombre.SetActive(true);
            BtnCerrarPanelSlots.interactable=false;
        }
    }

    public void GuardarBoton3(){

        SeñalBotonOprimido=3;

        string NivelGuardadoBoton3 = PlayerPrefs.GetString("NivelGuardadoBoton3");

        if(NivelGuardadoBoton3 != ""){
            
            PlayerPrefs.SetString("NivelGuardadoBoton3",NivelGuardar);
            //PanelGuardar.SetActive(false);
            TituloGuardadoConExito.SetActive(true);
        }else{
            PanelPedirNombre.SetActive(true);
            BtnCerrarPanelSlots.interactable=false;
        }
    }
    

    public void GuardarGeneral(){

        if(SeñalBotonOprimido==1){

            PlayerPrefs.SetString("NivelGuardadoBoton1",NivelGuardar);

            if(NombrePartida.text==""){

                PlayerPrefs.SetString("NombreSlot1","Ocupado");
            }else{
                PlayerPrefs.SetString("NombreSlot1",NombrePartida.text);
            }
            
            string NombreGuardado=PlayerPrefs.GetString("NombreSlot1");
            NombreSlot1.SetText(NombreGuardado);
            NombrePartida.text="";
        }
        if(SeñalBotonOprimido==2){

            PlayerPrefs.SetString("NivelGuardadoBoton2",NivelGuardar);
             if(NombrePartida.text==""){

                PlayerPrefs.SetString("NombreSlot2","Ocupado");
            }else{
                PlayerPrefs.SetString("NombreSlot2",NombrePartida.text);
            }
            string NombreGuardado=PlayerPrefs.GetString("NombreSlot2");
            NombreSlot2.SetText(NombreGuardado);
            NombrePartida.text="";
        }
        if(SeñalBotonOprimido==3){

            PlayerPrefs.SetString("NivelGuardadoBoton3",NivelGuardar);
             if(NombrePartida.text==""){

                PlayerPrefs.SetString("NombreSlot3","Ocupado");
            }else{
                PlayerPrefs.SetString("NombreSlot3",NombrePartida.text);
            }
            string NombreGuardado=PlayerPrefs.GetString("NombreSlot3");
            NombreSlot3.SetText(NombreGuardado);
            NombrePartida.text="";
        }

        
    }

    public void EliminarGuardadoBoton1(){
        PlayerPrefs.SetString("NivelGuardadoBoton1","");
        PlayerPrefs.SetString("NombreSlot1","Slot 1");

        string NombreSlot=  PlayerPrefs.GetString("NombreSlot1");

        NombreSlot1.SetText(NombreSlot);


    }

    public void EliminarGuardadoBoton2(){
        PlayerPrefs.SetString("NivelGuardadoBoton2","");
        PlayerPrefs.SetString("NombreSlot2","Slot 2");

        string NombreSlot=  PlayerPrefs.GetString("NombreSlot2");

        NombreSlot2.SetText(NombreSlot);


    }

    public void EliminarGuardadoBoton3(){
        PlayerPrefs.SetString("NivelGuardadoBoton3","");
        PlayerPrefs.SetString("NombreSlot3","Slot 3");

        string NombreSlot=  PlayerPrefs.GetString("NombreSlot3");

        NombreSlot3.SetText(NombreSlot);


    }

   
}
