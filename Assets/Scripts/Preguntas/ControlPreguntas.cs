using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlPreguntas : MonoBehaviour
{

    string[] PreguntasFaciles={"----- you eat?", "Are you ----- home?", "----- you like the ice cream", "otra pregunta 1", "otra pregunta 2", 
                               "otra pregunta 3", "otra pregunta 4","otra pregunta 5","otra pregunta 6", "otra pregunta 7"};

    string[] RespuestasPreguntasFaciles={"Did", "at", "Do","respuesta 1" , "respuesta 2", "respuesta 3", "respuesta 4" , "respuesta 5", "respuesta 6", "respuesta 7"};

    int PosicionPregunta;

    public static string RespuestaCorrectaPregunta;


    public string TraerPregunta(string emocion){

        string Pregunta="";

       
        PosicionPregunta= Random.Range(0,9);

        if(emocion=="Alegria-Alta" || emocion=="Alegria-Baja"){

            Pregunta=PreguntasFaciles[PosicionPregunta];

        }

        if(emocion=="Tristeza-Alta" || emocion=="Tristeza-Baja"){

            Pregunta=PreguntasFaciles[PosicionPregunta];

        }

        if(emocion=="Ira-Alta" || emocion=="Ira-Baja"){

            Pregunta=PreguntasFaciles[PosicionPregunta];

        }

        if(emocion=="Miedo-Alta" || emocion=="Miedo-Baja"){

            Pregunta=PreguntasFaciles[PosicionPregunta];

        }

        return Pregunta;


    }

    public string[] TraerRespuestas(string emocion ){


        string[] respuestas=new string[3];

        if(emocion=="Alegria-Alta" || emocion=="Alegria-Baja" || 
            emocion=="Tristeza-Alta" || emocion=="Tristeza-Baja" ||
            emocion=="Miedo-Alta" || emocion=="Miedo-Baja" || 
            emocion=="Ira-Alta" || emocion=="Ira-Baja"){

            string RespuestaCorrecta=RespuestasPreguntasFaciles[PosicionPregunta];

            string RespuestaIncorrecta1=RespuestasPreguntasFaciles[Random.Range(0,9)];

            string RespuestaIncorrecta2=RespuestasPreguntasFaciles[Random.Range(0,9)];


            respuestas[0]=RespuestaCorrecta;
            respuestas[1]=RespuestaIncorrecta1;
            respuestas[2]=RespuestaIncorrecta2;
            
            RespuestaCorrectaPregunta=RespuestaCorrecta;


        }

        return respuestas;

        


    }


    
}
