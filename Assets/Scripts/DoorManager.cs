using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    public static bool PuertaMundo1=true;
    public static bool PuertaMundo2=false;
    public static bool PuertaMundo3=false;


    public Collider2D Puerta1;
    public Collider2D Puerta2;
    public Collider2D Puerta3;


    public GameObject Puerta1Imagen;
    public GameObject Puerta2Imagen;
    public GameObject Puerta3Imagen;

    void Start()
    {

        if (PuertaMundo1==true)
        {

            Puerta2.gameObject.SetActive(false);
            Puerta3.gameObject.SetActive(false);
        }

         if (PuertaMundo2==true)
        {

            Puerta1.gameObject.SetActive(false);
            Puerta1Imagen.SetActive(false);
            Puerta2Imagen.SetActive(false);
            Puerta3.gameObject.SetActive(false);
        }

        if (PuertaMundo3==true)
        {
            Puerta3Imagen.SetActive(false);
            Puerta2Imagen.SetActive(true);

            Puerta1.gameObject.SetActive(false);
            Puerta2.gameObject.SetActive(false);
        }




    }


}
