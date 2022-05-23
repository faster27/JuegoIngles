using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SistemaDeGuardado : MonoBehaviour
{
    
    public Button BotonContinuarCampana;
    string NivelGuardar;
    string NombreNivel;
    
    // Start is called before the first frame update
    
    void Awake(){


        
    }
    void Start()
    {
        Scene scene2 = SceneManager.GetActiveScene();
        NivelGuardar =scene2.name;

        NombreNivel=PlayerPrefs.GetString("NombreDeNivelGuardado");

        if(NivelGuardar=="MenuInicial" && NombreNivel!="" ){

            BotonContinuarCampana.interactable=true;
        }
    }

    public void Guardar(){

        PlayerPrefs.SetString("NombreDeNivelGuardado",NivelGuardar);

    }

    public void Cargar(){

        
        SceneManager.LoadScene(NombreNivel);

    }
}
