using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class ResultadoEncuestaEmocion : MonoBehaviour
{

    //Aqui se realiza todo el proceso para obener la emcoion con la cual se realizara las preguntas 
    //al momento de coger la llave y abrir la puerta

    public TMP_Dropdown DropDown1;
    public TMP_Dropdown DropDown2;
    public TMP_Dropdown DropDown3;
    public TMP_Dropdown DropDown4;
    public TMP_Dropdown DropDown5;
    public TMP_Dropdown DropDown6;
    public TMP_Dropdown DropDown7;
    public TMP_Dropdown DropDown8;
    public TMP_Dropdown DropDown9;
    public TMP_Dropdown DropDown10;
    public TMP_Dropdown DropDown11;
    public TMP_Dropdown DropDown12;
    public TMP_Dropdown DropDown13;
    public TMP_Dropdown DropDown14;
    public TMP_Dropdown DropDown15;
    public TMP_Dropdown DropDown16;

    int Valor1=0;
    int Valor2=0;
    int Valor3=0;
    int Valor4=0;
    int Valor5=0;
    int Valor6=0;
    int Valor7=0;
    int Valor8=0;
    int Valor9=0;
    int Valor10=0;
    int Valor11=0;
    int Valor12=0;
    int Valor13=0;
    int Valor14=0;
    int Valor15=0;
    int Valor16=0;

    float ValorAlegria=0;
    float ValorTristeza=0;
    float ValorMiedo=0;
    float ValorIra=0;

    public static string EmocionResultante;
    string ResultadoEmocion;

    


       
    public void ObtenerEmocion()
    {
        Valor1=DropDown1.value;
        Valor2=DropDown2.value; 
        Valor3=DropDown3.value; 
        Valor4=DropDown4.value; 
        Valor5=DropDown5.value; 
        Valor6=DropDown6.value; 
        Valor7=DropDown7.value; 
        Valor8=DropDown8.value;  
        Valor9=DropDown9.value; 
        Valor10=DropDown10.value; 
        Valor11=DropDown11.value; 
        Valor12=DropDown12.value; 
        Valor13=DropDown13.value; 
        Valor14=DropDown14.value; 
        Valor15=DropDown15.value; 
        Valor16=DropDown16.value; 

        ValorAlegria=SacarPuntuacion(Valor3,Valor6,Valor12,Valor15);
        ValorTristeza=SacarPuntuacion(Valor4,Valor7,Valor10,Valor16);
        ValorMiedo=SacarPuntuacion(Valor1,Valor5,Valor9,Valor13);
        ValorIra=SacarPuntuacion(Valor2,Valor8,Valor11,Valor14);

        EmocionResultante=ElegirMayor(ValorAlegria,ValorTristeza,ValorMiedo,ValorIra);


        Debug.Log("La emoción resultante es: " + EmocionResultante);
     
        
    }

    public float SacarPuntuacion(int valor1, int valor2, int valor3, int valor4)
    {
        float Resultado=0;
        float Division=4.0f;

        Resultado=(valor1+valor2+valor3+valor4)/Division;

        return Resultado;
    }

    public string ElegirMayor(float Alegria,float Tristeza, float Miedo, float Ira)
    {
        
        float ValorMayor;
        int Posicion;
        List<float> Lista = new List<float>();

        Lista.Add(Alegria);
        Lista.Add(Tristeza);
        Lista.Add(Miedo);
        Lista.Add(Ira);

        ValorMayor=Lista.Max();

        //Me saca el index de la primera aparicion del valor mayor
        
        Posicion=Lista.IndexOf(ValorMayor);

        if(Posicion==0){

            ResultadoEmocion="Alegria";
        }

         if(Posicion==1){

            ResultadoEmocion="Tristeza";
        }

         if(Posicion==2){

            ResultadoEmocion="Miedo";
        }

         if(Posicion==3){

            ResultadoEmocion="Ira";
        }

        


        return ResultadoEmocion;

    }
}
