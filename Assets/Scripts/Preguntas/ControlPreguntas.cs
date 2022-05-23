using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;



public class ControlPreguntas : MonoBehaviour
{

    //Cada array de strings contiene 62 elementos
    
    string[] PreguntasFacilesBajo={};
    string[] RespuestasPreguntasFacilesBajo={};

    string[] PreguntasFacilesAlto={};
    string[] RespuestasPreguntasFacilesAlto={};
    
    string[] PreguntasMedioBajo={};
    string[] RespuestasPreguntasMedioBajo={};

    string[] PreguntasMedioAlto={};
    string[] RespuestasPreguntasMedioAlto={};

    string[] PreguntasDificilBajo={};
    string[] RespuestasPreguntasDificilBajo={};

    string[] PreguntasDificilAlto={};
    string[] RespuestasPreguntasDificilAlto={};
    
    
    int PosicionPregunta;

    public static string RespuestaCorrectaPregunta;

 
    void Start(){

        //Aqui se lee los archivos para las preguntas y respuestas de la dificultad Facil Bajo
        string FileToReadPreguntasFacilesBajo = "ArchivosPreguntas/PreguntasFacilesBajo.txt";

        PreguntasFacilesBajo=File.ReadAllLines(FileToReadPreguntasFacilesBajo);

        string FileToReadRespuestasFacilesBajo = "ArchivosPreguntas/RespuestasPreguntasFacilesBajo.txt";

        RespuestasPreguntasFacilesBajo=File.ReadAllLines(FileToReadRespuestasFacilesBajo);

        //Aqui se lee los archivos para las preguntas y respuestas de la dificultad Facil Alto

        string FileToReadPreguntasFacilesAlto = "ArchivosPreguntas/PreguntasFacilesAlto.txt";

        PreguntasFacilesAlto=File.ReadAllLines(FileToReadPreguntasFacilesAlto);

        string FileToReadRespuestasFacilesAlto = "ArchivosPreguntas/RespuestasPreguntasFacilesAlto.txt";

        RespuestasPreguntasFacilesAlto=File.ReadAllLines(FileToReadRespuestasFacilesAlto);

        //Aqui se lee los archivos para las preguntas y respuestas de la dificultad Media Baja

        string FileToReadPreguntasMedioBajo = "ArchivosPreguntas/PreguntasMedioBajo.txt";

        PreguntasMedioBajo=File.ReadAllLines(FileToReadPreguntasMedioBajo);

        string FileToReadRespuestasMedioBajo = "ArchivosPreguntas/RespuestasPreguntasMedioBajo.txt";

        RespuestasPreguntasMedioBajo=File.ReadAllLines(FileToReadRespuestasMedioBajo);

        //Aqui se lee los archivos para las preguntas y respuestas de la dificultad Media Alta

        string FileToReadPreguntasMedioAlta = "ArchivosPreguntas/PreguntasMedioAlto.txt";

        PreguntasMedioAlto=File.ReadAllLines(FileToReadPreguntasMedioAlta);

        string FileToReadRespuestasPreguntasMedioAlta = "ArchivosPreguntas/RespuestasPreguntasMedioAlto.txt";

        RespuestasPreguntasMedioAlto=File.ReadAllLines(FileToReadRespuestasPreguntasMedioAlta);

        //Aqui se lee los archivos para las preguntas y respuestas de la dificultad Dificil Baja

        string FileToReadPreguntasDificilBajo = "ArchivosPreguntas/PreguntasDificilBajo.txt";

        PreguntasDificilBajo=File.ReadAllLines(FileToReadPreguntasDificilBajo);

        string FileToReadRespuestasPreguntasDificilBajo = "ArchivosPreguntas/RespuestasPreguntasDificilBajo.txt";

        RespuestasPreguntasDificilBajo=File.ReadAllLines(FileToReadRespuestasPreguntasDificilBajo);

        //Aqui se lee los archivos para las preguntas y respuestas de la dificultad Dificil Alta

        string FileToReadPreguntasDificilAlto = "ArchivosPreguntas/PreguntasDificilAlto.txt";

        PreguntasDificilAlto=File.ReadAllLines(FileToReadPreguntasDificilAlto);

        string FileToReadRespuestasPreguntasDificilAlto = "ArchivosPreguntas/RespuestasPreguntasDificilAlto.txt";

        RespuestasPreguntasDificilAlto=File.ReadAllLines(FileToReadRespuestasPreguntasDificilAlto);

        

    }

    public string TraerPregunta(string emocion){

        string Pregunta="";

        

        PosicionPregunta= Random.Range(0,PreguntasFacilesBajo.Length);

        if(emocion=="Alegria-Baja"){

            Pregunta=PreguntasDificilBajo[PosicionPregunta];

        }

         if(emocion=="Alegria-Alta"){

            Pregunta=PreguntasDificilAlto[PosicionPregunta];

        }

        if(emocion=="Tristeza-Baja"){

            Pregunta=PreguntasFacilesBajo[PosicionPregunta];

        }

        if(emocion=="Tristeza-Alta"){

            Pregunta=PreguntasFacilesAlto[PosicionPregunta];

        }

        if(emocion=="Ira-Baja" || emocion=="Miedo-Baja"){

            Pregunta=PreguntasMedioBajo[PosicionPregunta];

        }

        if(emocion=="Ira-Alta" || emocion=="Miedo-Alta"){

            Pregunta=PreguntasMedioAlto[PosicionPregunta];

        }

        return Pregunta;


    }

    public string[] TraerRespuestas(string emocion ){


        string[] respuestas=new string[3];

        if(emocion=="Tristeza-Baja"){
            string RespuestaCorrecta=RespuestasPreguntasFacilesBajo[PosicionPregunta];

            string RespuestaIncorrecta1=RespuestasPreguntasFacilesBajo[Random.Range(0,RespuestasPreguntasFacilesBajo.Length)];

            string RespuestaIncorrecta2=RespuestasPreguntasFacilesBajo[Random.Range(0,RespuestasPreguntasFacilesBajo.Length)];


            respuestas[0]=RespuestaCorrecta;
            respuestas[1]=RespuestaIncorrecta1;
            respuestas[2]=RespuestaIncorrecta2;

            

            
            RespuestaCorrectaPregunta=RespuestaCorrecta;
        }

        if(emocion=="Tristeza-Alta"){

            string RespuestaCorrecta=RespuestasPreguntasFacilesAlto[PosicionPregunta];

            string RespuestaIncorrecta1=RespuestasPreguntasFacilesAlto[Random.Range(0,RespuestasPreguntasFacilesAlto.Length)];

            string RespuestaIncorrecta2=RespuestasPreguntasFacilesAlto[Random.Range(0,RespuestasPreguntasFacilesAlto.Length)];

            respuestas[0]=RespuestaCorrecta;
            respuestas[1]=RespuestaIncorrecta1;
            respuestas[2]=RespuestaIncorrecta2;
            
            RespuestaCorrectaPregunta=RespuestaCorrecta;

        }

        if(emocion=="Miedo-Baja" || emocion=="Ira-Baja"){

            string RespuestaCorrecta=RespuestasPreguntasMedioBajo[PosicionPregunta];

            string RespuestaIncorrecta1=RespuestasPreguntasMedioBajo[Random.Range(0,RespuestasPreguntasMedioBajo.Length)];

            string RespuestaIncorrecta2=RespuestasPreguntasMedioBajo[Random.Range(0,RespuestasPreguntasMedioBajo.Length)];

            respuestas[0]=RespuestaCorrecta;
            respuestas[1]=RespuestaIncorrecta1;
            respuestas[2]=RespuestaIncorrecta2;
            
            RespuestaCorrectaPregunta=RespuestaCorrecta;
        }

        if(emocion=="Miedo-Alta" || emocion=="Ira-Alta"){
            string RespuestaCorrecta=RespuestasPreguntasMedioAlto[PosicionPregunta];

            string RespuestaIncorrecta1=RespuestasPreguntasMedioAlto[Random.Range(0,RespuestasPreguntasMedioAlto.Length)];

            string RespuestaIncorrecta2=RespuestasPreguntasMedioAlto[Random.Range(0,RespuestasPreguntasMedioAlto.Length)];

            respuestas[0]=RespuestaCorrecta;
            respuestas[1]=RespuestaIncorrecta1;
            respuestas[2]=RespuestaIncorrecta2;
            
            RespuestaCorrectaPregunta=RespuestaCorrecta;
        }

        if(emocion=="Alegria-Baja"){

            string RespuestaCorrecta=RespuestasPreguntasDificilBajo[PosicionPregunta];

            string RespuestaIncorrecta1=RespuestasPreguntasDificilBajo[Random.Range(0,RespuestasPreguntasDificilBajo.Length)];

            string RespuestaIncorrecta2=RespuestasPreguntasDificilBajo[Random.Range(0,RespuestasPreguntasDificilBajo.Length)];


            respuestas[0]=RespuestaCorrecta;
            respuestas[1]=RespuestaIncorrecta1;
            respuestas[2]=RespuestaIncorrecta2;
            
            RespuestaCorrectaPregunta=RespuestaCorrecta;


        }

         if(emocion=="Alegria-Alta"){

            string RespuestaCorrecta=RespuestasPreguntasDificilAlto[PosicionPregunta];

            string RespuestaIncorrecta1=RespuestasPreguntasDificilAlto[Random.Range(0,RespuestasPreguntasDificilAlto.Length)];

            string RespuestaIncorrecta2=RespuestasPreguntasDificilAlto[Random.Range(0,RespuestasPreguntasDificilAlto.Length)];


            respuestas[0]=RespuestaCorrecta;
            respuestas[1]=RespuestaIncorrecta1;
            respuestas[2]=RespuestaIncorrecta2;
            
            RespuestaCorrectaPregunta=RespuestaCorrecta;


        }

        System.Random random = new System.Random();
        respuestas = respuestas.OrderBy(x => random.Next()).ToArray();


        return respuestas;

        


    }

   



    
}
