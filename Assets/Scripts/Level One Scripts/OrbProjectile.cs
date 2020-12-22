using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbProjectile : MonoBehaviour
{
    
    public SpawnThrowableObject objectSpawner;

    public void Start()
    {
        objectSpawner.ActivateOrbInHand();

       
    }

    //IEnumerator DeactivateThisObject()
    //{
    //   yield return new WaitForSeconds(5);
    //    this.objectSpawner.SetActive(false);
    //}
}
