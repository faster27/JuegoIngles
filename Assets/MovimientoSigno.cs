using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSigno : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(20*Time.deltaTime*speed,20*Time.deltaTime*speed));

        
    }

    public void AnadirFuerza(){
        rb=GetComponent<Rigidbody2D>();
        rb.velocity=new Vector2(0f,0f);
        rb.AddForce(new Vector2(30*Time.deltaTime*speed,30*Time.deltaTime*speed));

    }

    
}
