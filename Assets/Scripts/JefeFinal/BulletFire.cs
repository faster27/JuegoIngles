using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public float Speed=2;

    public float LifeTime=2;

    public static bool left;

    public SpriteRenderer spriteRenderer;
    

    private void Start()
    {

        Destroy(gameObject,LifeTime);


    }

    private void Update(){

        if(left){

            transform.Translate(Vector2.left*Speed*Time.deltaTime);
            spriteRenderer.flipX=true;

        }
        else
        {

            transform.Translate(Vector2.right*Speed*Time.deltaTime);
            spriteRenderer.flipX=false;


        }



    }

}
