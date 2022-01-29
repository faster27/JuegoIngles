using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCollected : MonoBehaviour
{
    public AudioSource clip;
    public GameObject Cup;
    
    private void OnTriggerEnter2D(Collider2D Collision) {

        if(Collision.CompareTag("Player")){

            GetComponent<SpriteRenderer>().enabled=false;
            

           
            Cup.gameObject.SetActive(true);
            Destroy(gameObject,0.5f);

            clip.Play();


        }

    }
}
