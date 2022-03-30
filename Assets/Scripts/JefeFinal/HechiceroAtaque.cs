using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HechiceroAtaque : MonoBehaviour
{
   private float WaitedTime;

   public float WaitTimeToAttack=3;

   public Animator animator;

   public GameObject BulletPrefab;

   public Transform LaunchSpawnPoint;

   public AudioSource SonidoFireBall;

   private void Start()
   {

      WaitedTime=WaitTimeToAttack;

   }

   private void Update()
   {

      if(WaitedTime<=0)
      {

         WaitedTime=WaitTimeToAttack;
         animator.Play("Attack");
         Invoke("LaunchBullet",0.1f);

      }
      else{

         WaitedTime-=Time.deltaTime;

      }

   }


   public void LaunchBullet()
   {

      GameObject newBullet;
      SonidoFireBall.Play();
      newBullet=Instantiate(BulletPrefab,LaunchSpawnPoint.position,LaunchSpawnPoint.rotation);


   }
   
}

