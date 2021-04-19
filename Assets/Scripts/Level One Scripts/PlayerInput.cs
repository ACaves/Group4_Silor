using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerInput : MonoBehaviour
{
    public SteamVR_Action_Boolean shoot;
    public Camera cam;
    private Vector3 destination;
    public GameObject projectile;
    private bool leftHand;
    public Transform LHFirePoint, RHFirePoint;
    public float projectileSpeed = 30;
    private float fireRate = 3;

    private float timeToFire;


    // Update is called once per frame
    void Update()
    {
        if (shoot.GetStateDown(SteamVR_Input_Sources.LeftHand)&& Time.time>= timeToFire)
        {
            timeToFire = Time.time + 1;
            InstantiateProjectile(LHFirePoint);
            ShootProjectile();
        }

        if (shoot.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            timeToFire = Time.time + 1/fireRate;
            InstantiateProjectile(RHFirePoint);
            ShootProjectile();
        }
    }


    public void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        
            destination = hit.point;
            else
            destination = ray.GetPoint(1000);

        

    }

    public void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}
