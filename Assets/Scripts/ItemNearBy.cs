using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNearBy : MonoBehaviour
{
    public AudioSource itemNearby;

    // Start is called before the first frame update
    void Start()
    {
        itemNearby = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            itemNearby.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            itemNearby.Stop();
        }
    }
}
