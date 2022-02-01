using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
  public Animator animator;

  public float JumpForce =2f;

  private void OnCollisionEnter2D(Collision2D collision)
  {

      if(collision.transform.CompareTag("Player"))
      {

        collision.gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2.up*JumpForce);
        animator.Play("JumpAnimation");

      }

  }
}
