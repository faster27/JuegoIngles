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

    public Image ImagenBtnSlot1;
    public Image ImagenBtnSlot2;
    public Image ImagenBtnSlot3;

    public TextMeshProUGUI NombreSlot1;
    public TextMeshProUGUI NombreSlot2;
    public TextMeshProUGUI NombreSlot3;

    public TextMeshProUGUI TextoPanelConfirmacion;

    public Sprite ImagenSlotOcupado;
    public Sprite ImagenSlotDesocupado;

    public GameObject TituloGuardadoConExito;

    public TMP_InputField NombrePartida;

    public GameObject PanelPedirNombre;
    public GameObject PanelGuardar;
    public GameObject PanelConfirmacionSobrescribir;
    public GameObject TextoGuardadoConExito;

    private int BotonOprimido;
    private int BtnEliminarOprimido;

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

        string NombreNivel=PlayerPrefs.GetString("NivelGuardadoBoton1");
        string NombreNivel2=PlayerPrefs.GetString("NivelGuardadoBoton2");
        string NombreNivel3=PlayerPrefs.GetString("NivelGuardadoBoton3");

        if(NivelGuardar=="MenuInicial" && (NombreNivel!="" || NombreNivel2!="" || NombreNivel3!="")){

            BotonContinuarCampana.interactable=true;
        }

        if(NivelGuardar!="MenuInicial"){

            if(Slot1 != "" && Slot1!="Slot 1"){

            NombreSlot1.SetText(Slot1);
            ImagenBtnSlot1.GetComponent<Image>().sprite = ImagenSlotOcupado;
            }else{
                ImagenBtnSlot1.GetComponent<Image>().sprite = ImagenSlotDesocupado;

            }
            if(Slot2 != "" && Slot2!="Slot 2"){

                NombreSlot2.SetText(Slot2);
                ImagenBtnSlot2.GetComponent<Image>().sprite = ImagenSlotOcupado;
            }else{
                ImagenBtnSlot2.GetComponent<Image>().sprite = ImagenSlotDesocupado;
            }
            if(Slot3 != "" && Slot3!="Slot 3"){

                NombreSlot3.SetText(Slot3);
                ImagenBtnSlot3.GetComponent<Image>().sprite = ImagenSlotOcupado;
            }else{
                ImagenBtnSlot3.GetComponent<Image>().sprite = ImagenSlotDesocupado;
            }
        }

        

       

        


    }

    public void GuardarConfirmado(){

        if(BtnEliminarOprimido==1 || BtnEliminarOprimido==2 ||BtnEliminarOprimido==3 ){

            EliminarGeneral();
        }else{
            if(BotonOprimido==1){
            PlayerPrefs.SetString("NivelGuardadoBoton1",NivelGuardar);
            TituloGuardadoConExito.SetActive(true);
            PanelConfirmacionSobrescribir.SetActive(false);
            BtnCerrarPanelSlots.interactable=true;

            }
            if(BotonOprimido==2){
                PlayerPrefs.SetString("NivelGuardadoBoton2",NivelGuardar);
                TituloGuardadoConExito.SetActive(true);
                PanelConfirmacionSobrescribir.SetActive(false);
                BtnCerrarPanelSlots.interactable=true;
            }
            if(BotonOprimido==3){
                PlayerPrefs.SetString("NivelGuardadoBoton3",NivelGuardar);
                TituloGuardadoConExito.SetActive(true);
                PanelConfirmacionSobrescribir.SetActive(false);
                BtnCerrarPanelSlots.interactable=true;
            }

        }

        
        

    }

    public void GuardarBoton1(){

        SeñalBotonOprimido=1;

        string NivelGuardadoBoton1 = PlayerPrefs.GetString("NivelGuardadoBoton1");

        if(NivelGuardadoBoton1 != ""){

           TextoPanelConfirmacion.text="¿Desea sobrescribir la partida en este slot?";
           PanelConfirmacionSobrescribir.SetActive(true);
           BtnCerrarPanelSlots.interactable=false;
           BotonOprimido=1;
           
        }else{
            PanelPedirNombre.SetActive(true);
            BtnCerrarPanelSlots.interactable=false;
        }
    }

   

    public void GuardarBoton2(){

        SeñalBotonOprimido=2;

        string NivelGuardadoBoton2 = PlayerPrefs.GetString("NivelGuardadoBoton2");

        if(NivelGuardadoBoton2 != ""){

            TextoPanelConfirmacion.text="¿Desea sobrescribir la partida en este slot?";
            PanelConfirmacionSobrescribir.SetActive(true);
            BtnCerrarPanelSlots.interactable=false;
            BotonOprimido=2;
              
        }else{
            PanelPedirNombre.SetActive(true);
            BtnCerrarPanelSlots.interactable=false;
        }
    }

    public void GuardarBoton3(){

        SeñalBotonOprimido=3;

        string NivelGuardadoBoton3 = PlayerPrefs.GetString("NivelGuardadoBoton3");

        if(NivelGuardadoBoton3 != ""){
            
            TextoPanelConfirmacion.text="¿Desea sobrescribir la partida en este slot?";
            PanelConfirmacionSobrescribir.SetActive(true);
            BtnCerrarPanelSlots.interactable=false;
            BotonOprimido=3;
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
            ImagenBtnSlot1.GetComponent<Image>().sprite = ImagenSlotOcupado;
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
            ImagenBtnSlot2.GetComponent<Image>().sprite = ImagenSlotOcupado;
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
            ImagenBtnSlot3.GetComponent<Image>().sprite = ImagenSlotOcupado;
        }

        
    }

    public void EliminarGeneral(){

        if(BtnEliminarOprimido==1){
            PlayerPrefs.SetString("NivelGuardadoBoton1","");
            PlayerPrefs.SetString("NombreSlot1","Slot 1");

            string NombreSlot=  PlayerPrefs.GetString("NombreSlot1");

            NombreSlot1.SetText(NombreSlot);
            ImagenBtnSlot1.GetComponent<Image>().sprite = ImagenSlotDesocupado;
            PanelConfirmacionSobrescribir.SetActive(false);
            BtnCerrarPanelSlots.interactable=true;
            BtnEliminarOprimido=0;
            TextoGuardadoConExito.SetActive(false);

        }
        if(BtnEliminarOprimido==2){
            PlayerPrefs.SetString("NivelGuardadoBoton2","");
            PlayerPrefs.SetString("NombreSlot2","Slot 2");

            string NombreSlot=  PlayerPrefs.GetString("NombreSlot2");

            NombreSlot2.SetText(NombreSlot);
            ImagenBtnSlot2.GetComponent<Image>().sprite = ImagenSlotDesocupado;
            PanelConfirmacionSobrescribir.SetActive(false);
            BtnCerrarPanelSlots.interactable=true;
            BtnEliminarOprimido=0;
            TextoGuardadoConExito.SetActive(false);

        }
        if(BtnEliminarOprimido==3){
            PlayerPrefs.SetString("NivelGuardadoBoton3","");
            PlayerPrefs.SetString("NombreSlot3","Slot 3");

            string NombreSlot=  PlayerPrefs.GetString("NombreSlot3");

            NombreSlot3.SetText(NombreSlot);
            ImagenBtnSlot3.GetComponent<Image>().sprite = ImagenSlotDesocupado;
            PanelConfirmacionSobrescribir.SetActive(false);
            BtnCerrarPanelSlots.interactable=true;
            BtnEliminarOprimido=0;
            TextoGuardadoConExito.SetActive(false);
        }
    }

    public void EliminarGuardadoBoton1(){
        BtnEliminarOprimido=1;
        TextoPanelConfirmacion.text="¿Desea eliminar la partida?";
    }

    public void EliminarGuardadoBoton2(){  
        BtnEliminarOprimido=2;
        TextoPanelConfirmacion.text="¿Desea eliminar la partida?";
    }

    public void EliminarGuardadoBoton3(){
        BtnEliminarOprimido=3;
        TextoPanelConfirmacion.text="¿Desea eliminar la partida?";
    }

   
}
