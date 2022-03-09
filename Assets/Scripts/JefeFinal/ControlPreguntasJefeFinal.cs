using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlPreguntasJefeFinal : MonoBehaviour
{
    public GameObject PanelPreguntas;
    
    public Button Btn1;
    public Button Btn2;
    public Button Btn3;

    public static bool AnswerIsCorrect=false;

    public JumpDamageFinalBoss FinalBoss; 
    

    void Start () {
		Button Btn11 = Btn1.GetComponent<Button>();
		Btn11.onClick.AddListener(() => ObtenerRespuesta(1));

        Button Btn22 = Btn2.GetComponent<Button>();
		Btn22.onClick.AddListener(() => ObtenerRespuesta(2));

        Button Btn33 = Btn3.GetComponent<Button>();
		Btn33.onClick.AddListener(() => ObtenerRespuesta(3));


        FinalBoss = new JumpDamageFinalBoss();

        FinalBoss=FindObjectOfType<JumpDamageFinalBoss>();
	}
    
    private void ObtenerRespuesta(int Buton)
    {

        if(Buton==1){
            string respuesta= Btn1.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            FinalBoss.IsCorrect(respuesta);

           

        }

         if(Buton==2){
            string respuesta= Btn2.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            FinalBoss.IsCorrect(respuesta);

        }

         if(Buton==3){
            string respuesta= Btn3.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            Debug.Log(respuesta);
            FinalBoss.IsCorrect(respuesta);

        }
     

        
        
    }

   
    
}
