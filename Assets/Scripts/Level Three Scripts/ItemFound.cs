using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ItemFound : MonoBehaviour
{
    public GameObject[] tickPrefab;
    public Text ItemTextName;
    public GameObject itemCanvas;
    public GameObject helmetPrefab;
    public GameObject hammerPrefab;
    public GameObject swordPrefab;
    public GameObject shieldPrefab;
    public LayerMask pickUpLayer;
    public float distToPickup = 0.3f;
    bool handClosed = false;

    Rigidbody holdingTarget;

    public SteamVR_Input_Sources handSource = SteamVR_Input_Sources.LeftHand;


    public SteamVR_Action_Boolean pickUpAction;
    private void Start()
    {
        tickPrefab[0].SetActive(false);
        tickPrefab[1].SetActive(false);
        tickPrefab[2].SetActive(false);
        tickPrefab[3].SetActive(false);

        helmetPrefab.SetActive(true);
        hammerPrefab.SetActive(true);
        swordPrefab.SetActive(true);
        shieldPrefab.SetActive(true);

    }

    public void FixedUpdate()
    {
        if (SteamVR_Actions.default_GrabPinch.GetStateDown(handSource))
        
            handClosed = true;
            else
            handClosed = false;

        if (!handClosed)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, distToPickup, pickUpLayer);

            if (colliders.Length > 0)
            {
                holdingTarget = colliders[0].transform.root.GetComponent<Rigidbody>();

            }
            else
            {
                holdingTarget = null;
            }

        }


        else
        {
            if (holdingTarget)
            {
                holdingTarget.velocity = (transform.position - holdingTarget.transform.position)/Time.fixedDeltaTime;
                holdingTarget.maxAngularVelocity = 20;
                Quaternion deltaRot = transform.rotation * Quaternion.Inverse(holdingTarget.rotation);
                Vector3 eulerRot = new Vector3(Mathf.DeltaAngle(0, deltaRot.eulerAngles.x),
                                         Mathf.DeltaAngle(0, deltaRot.eulerAngles.y), Mathf.DeltaAngle(0, deltaRot.eulerAngles.z));
                eulerRot *= 0.95f;
                eulerRot *= Mathf.Deg2Rad;
                holdingTarget.angularVelocity = eulerRot / Time.fixedDeltaTime;


                if (holdingTarget.tag=="Helmet")
                {
                    helmetPrefab.SetActive(false);
                    tickPrefab[0].SetActive(true);
                }

                else if (holdingTarget.tag == "Hammer")
                {
                    hammerPrefab.SetActive(false);
                    tickPrefab[1].SetActive(true);
                }

                else if (holdingTarget.tag =="Sword")
                {
                    swordPrefab.SetActive(false);
                    tickPrefab[2].SetActive(true);
                }

                else if (holdingTarget.tag == "Shield")
                {
                    shieldPrefab.SetActive(false);
                    tickPrefab[3].SetActive(true);
                }
            }
        }
         
        
    }
}
