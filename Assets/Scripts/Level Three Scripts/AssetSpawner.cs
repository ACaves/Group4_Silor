using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSpawner : MonoBehaviour
{
    public GameObject assetObject;

    // Start is called before the first frame update
    void Start()
    {
        assetObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
