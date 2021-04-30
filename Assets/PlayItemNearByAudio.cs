using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayItemNearByAudio : MonoBehaviour
{
    public AudioSource itemNearby;

    private void Start()
    {
        itemNearby.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player entered sound area");
            itemNearby.Play();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player exited sound area");
            itemNearby.Stop();
        }
    }
}
