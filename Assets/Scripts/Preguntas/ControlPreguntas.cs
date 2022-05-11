using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlPreguntas : MonoBehaviour
{

    string[] PreguntasFacilesBajo={"I ..... to watch movies", "I ..... to go hiking", "I ..... to relax at home", "When I have free time, I ..... to travel", "In my free time, I ..... to study English", 
                               "I ..... to paint when I have time", "Two boys played with a ball ......","We need to speak ......","She woke up early in the ......", "The movie ended five ......",
                               "The plane landed two ......","My son was born six ......","Her husband died ten ......","I took that photo many ......","I came to this city a ......",
                               "I saw a game on TV ......","Michael arrived in Mexico ......","..... I got a lot of presents","..... Jake and Jill got married","We got up early ..... in the morning",
                               "..... evening Joel called me","I went shopping three ......","I bought a pair of shoes ......","I went on a date ......","I played football ......",
                               "They went to the office ......","What did you do .....?","I ..... my hair every nigth","I pack my things .....","I ..... my teeth everyday",
                               "I saw my books ..... the school","I ..... my hands before to eat","I run to school .....","They lived in Spain for five ......","He smoked a cigarette ......",
                               "..... I did exercise.","I met him .....","I saw him two .....","I worked there for 4 .....","We ..... play tennis",
                               "She came back ......","He bought a new house ......","I missed the class ......","They were students ......","Joe lived in Boston for ten ......",
                               "He doesn't play soccer .....","They did not run .....","Did they run .....?","Where did you go .....?","What did you do .....?",
                               "I dream of you ......","I wash my car .....","I must go to the work .....","I ..... at 5 am every day","Michael studied hard ......",
                               "Did he play soccer .....?","Did you cook dinner .....?","What exercises did you do .....?","This bus leaves at 10 o'clock .....","She came to visit me .....",
                               "I played soccer ..... May ..... June","Did I go to the store .....?"};

    string[] RespuestasPreguntasFacilesBajo={"like", "love", "like","love" , "like", "like", "yesterday" , "now", "morning", "minutes ago", 
                                        "hours ago","months ago","years ago","years ago","long time ago","last night","last January","Last Christmas",
                                        "Last year","yesterday","Yesterday","month ago","last year","last month","yesterday","early","last week","brush",
                                        "every moorning","clean","after","wash","everyday","years","every weekend","Yesterday","yesterday","weeks ago",
                                        "weeks","usually","last Thursday","last month","last week","last year","years","every day","yesterday","yesterday",
                                        "last night","last night","every night","on saturdays","everyday","got up","all the year","last week","last night",
                                        "yesterday","today","last year","from - to","last month"};

    string[] PreguntasFacilesAlto={};

    string[] RespuestasPreguntasFacilesAlto={};


    
    
    int PosicionPregunta;

    public static string RespuestaCorrectaPregunta;

 


    public string TraerPregunta(string emocion){

        string Pregunta="";

        

        PosicionPregunta= Random.Range(0,PreguntasFacilesBajo.Length);

        if(emocion=="Alegria-Alta" || emocion=="Alegria-Baja"){

            Pregunta=PreguntasFacilesBajo[PosicionPregunta];

        }

        if(emocion=="Tristeza-Alta" || emocion=="Tristeza-Baja"){

            Pregunta=PreguntasFacilesBajo[PosicionPregunta];

        }

        if(emocion=="Ira-Alta" || emocion=="Ira-Baja"){

            Pregunta=PreguntasFacilesBajo[PosicionPregunta];

        }

        if(emocion=="Miedo-Alta" || emocion=="Miedo-Baja"){

            Pregunta=PreguntasFacilesBajo[PosicionPregunta];

        }

        return Pregunta;


    }

    public string[] TraerRespuestas(string emocion ){


        string[] respuestas=new string[3];

        if(emocion=="Alegria-Alta" || emocion=="Alegria-Baja" || 
            emocion=="Tristeza-Alta" || emocion=="Tristeza-Baja" ||
            emocion=="Miedo-Alta" || emocion=="Miedo-Baja" || 
            emocion=="Ira-Alta" || emocion=="Ira-Baja"){

            string RespuestaCorrecta=RespuestasPreguntasFacilesBajo[PosicionPregunta];

            string RespuestaIncorrecta1=RespuestasPreguntasFacilesBajo[Random.Range(0,RespuestasPreguntasFacilesBajo.Length)];

            string RespuestaIncorrecta2=RespuestasPreguntasFacilesBajo[Random.Range(0,RespuestasPreguntasFacilesBajo.Length)];


            respuestas[0]=RespuestaCorrecta;
            respuestas[1]=RespuestaIncorrecta1;
            respuestas[2]=RespuestaIncorrecta2;
            
            RespuestaCorrectaPregunta=RespuestaCorrecta;


        }

        return respuestas;

        


    }


    
}
