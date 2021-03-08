using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AC_Shooter : MonoBehaviour
{ 
    private AC_ProjectilePools a_ProjectilePool = null;

    public GameObject a_Orbs =null;

    public SteamVR_Action_Boolean o_FireAction = null;

    public int o_Force = 10;

    public Transform o_SpawnLocation;

    private SteamVR_Behaviour_Pose o_Pose =null;

    private void Awake()
    {
        //o_Pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        //Debug.Log("behaviour pose obtained");
        a_ProjectilePool = new AC_ProjectilePools(a_Orbs, 10);
    }

    private void Update()
    {
        if (SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Fire();
            Debug.Log("shooter trigger pressed");
        }


        //if (o_FireAction.GetStateDown(o_Pose.inputSource))
        //{
        //    Fire();
        //    Debug.Log("trigger pulled");
        //}
    }

    private void Fire()
    {
        AC_Projectiles targetProjectile = a_ProjectilePool.a_Projectile[0];
        targetProjectile.Launch(this);
        Debug.Log("Projectile pool created");
    }
}
