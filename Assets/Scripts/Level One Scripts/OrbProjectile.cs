using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbProjectile : MonoBehaviour
{
    
    public SpawnThrowableObject objectSpawner;


    public void OnTriggerEnter(Collider other)//destroys the throwable object once the object enters a trigger
    {
        if (other.gameObject.tag == "Enemy")
        {
            objectSpawner.ActivateOrbInHand();
            Destroy(gameObject);

            
        }

       

    }
}
