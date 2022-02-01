using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    

    public float Speed =0.5f;

    private float WaitTime;

    public Transform[] MovesSpots; 

    public float StartWaitTime=2;

    private int i=0;

  


    void Start()
    {
        WaitTime=StartWaitTime;


    }

    void Update()
    {
        

        transform.position=Vector2.MoveTowards(transform.position, MovesSpots[i].transform.position,Speed*Time.deltaTime);

        if(Vector2.Distance(transform.position,MovesSpots[i].transform.position)<0.1f)
        {
            if(WaitTime<=0)
            {

                if(MovesSpots[i]!=MovesSpots[MovesSpots.Length-1])
                {

                    i++;
                }
                else
                {

                    i=0;
                }

                WaitTime=StartWaitTime;

            }
            else
            {


                WaitTime-=Time.deltaTime;



            }

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        collision.collider.transform.SetParent(transform);

    }

     private void OnCollisionExit2D(Collision2D collision)
    {

        collision.collider.transform.SetParent(null);

    }

}
