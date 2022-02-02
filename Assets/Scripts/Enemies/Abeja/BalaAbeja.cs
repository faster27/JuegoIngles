using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaAbeja : MonoBehaviour
{
    public float Speed=2;

    public float TiempoVida=2;

    private void Start()
    {

       Destroy(gameObject,TiempoVida);


    }

    private void Update()
    {

        transform.Translate(Vector2.down*Speed*Time.deltaTime);

    }
}
