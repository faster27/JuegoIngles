using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincesaController : MonoBehaviour
{
    
  


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.CompareTag("Princesa")){

         
            collision.collider.transform.SetParent(transform);
            collision.transform.GetComponent<Rigidbody2D>().isKinematic=true;
            collision.transform.GetComponent<BoxCollider2D>().enabled=false;
            
            


        }

    }
}
