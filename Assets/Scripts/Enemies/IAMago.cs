using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMago : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float Speed =0.5f;

    private float WaitTime;

    public Transform[] MovesSpots; 

    public float StartWaitTime=2;

    private int i=0;

    private Vector2 ActualPos;

    public GameObject BulletSpawnPoint;

    private Vector3 PosIzq;
    
    private Vector3 PosDer;

    private float y;


    void Start()
    {
        WaitTime=StartWaitTime;
        PosIzq=new Vector3(-0.4f,0.03f,0f);
        PosDer=new Vector3(0.4f,0.03f,0f);


    }

    void Update()
    {
       
        StartCoroutine(CheckEnemyMoving());

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



    IEnumerator CheckEnemyMoving()
    {

       
        ActualPos=transform.position;

        yield return new WaitForSeconds(0.5f);


        if ( transform.position.x>=ActualPos.x)
        {

            spriteRenderer.flipX=false;
            animator.SetBool("Idle",false);
            BulletFire.left=false;

            BulletSpawnPoint.transform.localPosition=PosDer;
            
         

        }
        else if (transform.position.x<=ActualPos.x){
            spriteRenderer.flipX=true;
            animator.SetBool("Idle",false);
            BulletFire.left=true;
            
            BulletSpawnPoint.transform.localPosition=PosIzq;

        }
       


    }

}

