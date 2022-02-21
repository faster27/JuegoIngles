using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJefeFinal : MonoBehaviour
{



    public GameObject Jaula;
    public GameObject AnimacionPuerta;
    public AudioSource Celebracion;
    public AudioSource Musica;
    private AudioClip otherClip;

    // Start is called before the first frame update
    void Start()
    {
        otherClip=Celebracion.clip;
    }

    // Update is called once per frame
    void Update()
    {
        if(JumpDamage.IsDead==true)
        {
            Jaula.SetActive(false);
            AnimacionPuerta.SetActive(true);
            Musica.Stop();
            Celebracion.Play();
            

        }
         
    }

  


}
