using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float speed = 1000f;
    public GameObject orbPrefab;
    public Rigidbody orbRb;
    
    public AudioSource krakenAudio;


    // Start is called before the first frame update
    void Start()
    {
        
        krakenAudio.GetComponent<AudioSource>();
        //Rigidbody orbRb = GetComponent<Rigidbody>();

        //orbRb.velocity = transform.forward * speed;
        orbRb.AddForce(Vector3.forward * speed);
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
       Debug.Log(hitInfo.name);
       
        if (hitInfo.gameObject.tag=="Enemy")
        {
            Score.scoreValue += 1;
            
            Debug.Log("Enemy Hit");
            krakenAudio.Play();
            
            Destroy(hitInfo.gameObject);
        }

    }

    private void Update()
    {
        Destroy(gameObject, 5f);
    }

}
