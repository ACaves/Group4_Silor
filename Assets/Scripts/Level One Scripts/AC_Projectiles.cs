using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_Projectiles : MonoBehaviour
{
    public float o_Lifetime = 5.0f;
    private Rigidbody o_Rigidbody = null;
    public int o_Force = 10;


    private void Awake()
    {
        o_Rigidbody = GetComponent<Rigidbody>();
        SetInactive();
    }

    private void OnCollisionEnter(Collision collision) // projectile 
    {
        SetInactive();
    }

    public void Launch(AC_Shooter blaster)
    {
        //Position with player
        transform.position = blaster.o_SpawnLocation.position;
        transform.rotation = blaster.o_SpawnLocation.rotation;

        //Activate
        gameObject.SetActive(true);

        //Fire, Force and Track Location
        o_Rigidbody.AddRelativeForce(Vector3.forward * o_Force, ForceMode.Impulse);
        StartCoroutine(TrackLifeTime());
    }

    private IEnumerator TrackLifeTime()
    {
        yield return new WaitForSeconds(o_Lifetime);
        SetInactive();
    }

    public void SetInactive() //resets projectile to stop movement for new projectiles
    {
        o_Rigidbody.velocity = Vector3.zero;
        o_Rigidbody.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }


}
