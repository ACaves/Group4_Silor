using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_Projectiles : MonoBehaviour
{
    public float o_Lifetime = 5.0f;
    private Rigidbody o_Rigidbody = null;

    private void Awake()
    {
        o_Rigidbody = GetComponent<Rigidbody>();
        SetInactive();
    }

    private void OnCollisionEnter(Collision collision) // projectile 
    {
        SetInactive();
    }

    public void Launch()
    {
        //Position in VR Hands 
        

        //Activate

        //Fire and Track Location
    }

    //private IEnumerator TrackLifeTime()
    //{
    //    yield return new //
    //}

    public void SetInactive()
    {

    }


}
