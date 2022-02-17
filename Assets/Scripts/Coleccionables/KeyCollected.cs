using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollected : MonoBehaviour
{
    public AudioSource clip;
    public GameObject Key;
    public GameObject PanelPreguntas;
    public static bool IsKeyCollected=false;
    
    private void OnTriggerEnter2D(Collider2D Collision) {

        if(Collision.CompareTag("Player")){

            PanelPreguntas.gameObject.SetActive(true);
            Time.timeScale=0;

            


        }

    }

    public void IsCorrect()
    {
            
        PanelPreguntas.gameObject.SetActive(false);
        Time.timeScale=1;

        IsKeyCollected=true;
        GetComponent<SpriteRenderer>().enabled=false;
            
        Key.gameObject.SetActive(true);
        Destroy(gameObject,0.5f);

        clip.Play();
    }
}
