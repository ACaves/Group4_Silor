using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SpawnThrowableObject : MonoBehaviour
{
   
    public OrbProjectile orbProjectilePrefab;
    public Transform spawnLocation;

    public SteamVR_Input_Sources thisHand;
    private SteamVR_Behaviour_Pose m_pose = null;


    public OrbInHand orbInHand;
    public Valve.VR.InteractionSystem.Player thePlayer;//variable of type valve.vr.interactionsystem referencing the player

    public void SpawnObject()//spawn throwable object within the scene
    {
        
        
            OrbProjectile newOrb = Instantiate(orbProjectilePrefab) as OrbProjectile;
            newOrb.transform.position = thePlayer.rightHand.transform.position;
            newOrb.objectSpawner = this;
            DeactivateOrbInHand();
            Debug.Log("throwable object spawned");
        StartCoroutine(DeactivateSpawnedProjectile());

        Debug.Log("spawn object function has been called");

        
    }

    public void ActivateOrbInHand()
    {
        orbInHand.gameObject.SetActive(true);
    }

    public void DeactivateOrbInHand()
    {
        orbInHand.gameObject.SetActive(false);
    }

    private void Update()
    {
<<<<<<< HEAD
        if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.Any))//accesses input from steam vr using grab grip option to spawn throwable projectile
        
        {
            SpawnObject();
=======
        if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.LeftHand))//accesses input from steam vr using grab grip option to spawn throwable projectile
        
        {
            SpawnObject();
        }

        if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand))//accesses input from steam vr using grab grip option to spawn throwable projectile

        {
            SpawnObject();
>>>>>>> parent of 234f046... Level One movement script edited
        }
    }

    IEnumerator DeactivateSpawnedProjectile()
    {
        yield return new WaitForSeconds(10);
        //find gameobject to deactivate    


    }

    //public void Fire()
    //{
        
    //}
}
