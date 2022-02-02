using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaida : MonoBehaviour
{
    
    public float RetrasoCaida=0.3f;

    public Collider2D collider;
   

    Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(Caida(RetrasoCaida));
            
            

        }

    }

    IEnumerator Caida(float delay)
    {

        yield return new WaitForSeconds(delay);

        rb.bodyType=RigidbodyType2D.Dynamic;
        
        yield return new WaitForSeconds(0.1f);
        GetComponent<Collider2D>().enabled = false;




    }
}
