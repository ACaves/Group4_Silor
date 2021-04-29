using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float speed = 1000f;
    public Rigidbody orbRb;

    // Start is called before the first frame update
    void Start()
    {
        //orbRb.velocity = transform.forward * speed;
        orbRb.AddForce(Vector3.forward * speed);
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
       Debug.Log(hitInfo.name);
       
        if (hitInfo.gameObject.tag=="Enemy")
        {
            Destroy(hitInfo.gameObject);
        }

    }

    private void Update()
    {
        Destroy(gameObject, 5f);
    }

}
