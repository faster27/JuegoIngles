using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
     private void OnCollisionEnter2D(Collision2D Collision){

        if(Collision.transform.CompareTag("Player")){

            
            Collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();


        }



    }
}
