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


    //private void OnTriggerEnter(GameObject other)
    //{
    //    if (other.gameObject.tag=="Player")
    //    {
    //        Debug.Log("'Player entered Trigger");
    //        itemNearby.Play();
    //    }
        
        
        
    //}


    //private void OnTriggerExit(GameObject other)
    //{
    //    itemNearby.Stop();
    //}
}
