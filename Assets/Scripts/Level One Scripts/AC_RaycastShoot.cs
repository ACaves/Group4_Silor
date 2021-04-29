
using Valve.VR;
using UnityEngine;

public class AC_RaycastShoot : MonoBehaviour
{
    public Transform firePoint;
    public float damage = 30f;
    public float range = 1000f;
    public Camera fpsCam;

    public SteamVR_Action_Boolean shootorb;

     void Update()
    {
        if (shootorb.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Shoot();
           
            Debug.Log("Left trigger used");
        }

        else if (shootorb.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            Shoot();
            Debug.Log("Right trigger used");
        }
    }


    void Shoot()
    {
        RaycastHit hit;

       if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.localPosition, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }


    }
}


