using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaulaController : MonoBehaviour
{
    
    public GameObject Jaula;
     public  GameObject AnimacionPuerta;
     public GameObject Princesa;
    
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.CompareTag("Player")){

            Jaula.SetActive(false);
            AnimacionPuerta.SetActive(true);
            Princesa.transform.SetParent(null);
              
            


        }

    }
}
