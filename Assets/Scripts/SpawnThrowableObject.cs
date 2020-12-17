using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThrowableObject : MonoBehaviour
{
    public GameObject throwableObject;
    public Transform spawnLocation;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(throwableObject, spawnLocation.transform.position, spawnLocation.transform.rotation);
    }

  
}
