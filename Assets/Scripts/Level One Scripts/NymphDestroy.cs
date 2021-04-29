using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NymphDestroy : MonoBehaviour
{

    // add particle effect variable 
  
    public GameObject nymphEnemy;
    //public Animator krakenDeathAnimation;
    //public static int scoreValue = 0;


    //private void OnCollisionEnter(Collision collision)
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Enemy")
        {

            //Destroy(this.gameObject);
            Debug.Log("projectile hit enemy");
            //krakenDeathAnimation.Play(dea)
            //add score when able with UI see level 2 scripts box
        }
    }



}
