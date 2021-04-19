using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NymphDestroy : MonoBehaviour
{

    // add particle effect variable 
  
    public GameObject nymphEnemy;
    public static int scoreValue = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile")
        {

            Destroy(this.gameObject);
            
            //add score when able with UI see level 2 scripts box
        }
    }



}
