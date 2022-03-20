using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJefeFinal : MonoBehaviour
{

  
   
    public  AudioSource Musica;
    public  AudioClip Celebracion;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
         
    }

    public void CambiarAudioClip()
    {
        
      
        Musica.Stop();
        Musica.clip=Celebracion;
        Musica.loop=false;
        Musica.Play();

    }

  


}
