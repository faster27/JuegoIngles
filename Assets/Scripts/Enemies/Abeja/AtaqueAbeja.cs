using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueAbeja : MonoBehaviour
{
   
    public Animator animator;

    public float DistanciaRayCast=0.5f;

    public float TiempoAtaque=1f;

    private float ConteoActual;

    public GameObject Bala;

    public Transform LaunchSpawnPoint;


   
   
    // Start is called before the first frame update
    void Start()
    {
        ConteoActual=0;
    }

    // Update is called once per frame
    void Update()
    {
        ConteoActual-=Time.deltaTime;

        Debug.DrawRay(transform.position,Vector2.down,Color.red,DistanciaRayCast);
    }

    private void FixedUpdate()
    {

        RaycastHit2D hit2D=Physics2D.Raycast(transform.position,Vector2.down,DistanciaRayCast);

        if(hit2D.collider!=null)
        {

            if(hit2D.collider.CompareTag("Player") )
            {

                if(ConteoActual<0)
                {
                    Invoke("DisparoBala",0.5f);
                    animator.Play("Attack");
                    ConteoActual=TiempoAtaque;
                }

            }

        }
    }

    void DisparoBala()
    {

        GameObject BalaNueva;

        BalaNueva=Instantiate(Bala,LaunchSpawnPoint.position,LaunchSpawnPoint.rotation);

    }
}
