using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbProjectile : MonoBehaviour
{
    private bool collided;

    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag !="projectile"&& co.gameObject.tag!= "Player" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }
    }



}
