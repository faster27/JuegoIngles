using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlant : MonoBehaviour
{
    public float Speed=2;

    public float LifeTime=2;

    public bool left;

    private void Start()
    {

        Destroy(gameObject,LifeTime);


    }

    private void Update(){

        if(left){

            transform.Translate(Vector2.left*Speed*Time.deltaTime);

        }
        else
        {

            transform.Translate(Vector2.right*Speed*Time.deltaTime);


        }



    }

}
