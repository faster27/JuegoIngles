using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollected : MonoBehaviour
{
    public AudioSource clip;
    public GameObject Key;
    public static bool IsKeyCollected=false;
    
    private void OnTriggerEnter2D(Collider2D Collision) {

        if(Collision.CompareTag("Player")){

            IsKeyCollected=true;
            GetComponent<SpriteRenderer>().enabled=false;
            
            Key.gameObject.SetActive(true);
            Destroy(gameObject,0.5f);

            clip.Play();


        }

    }
}
