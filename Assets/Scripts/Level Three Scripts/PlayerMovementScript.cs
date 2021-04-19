using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerMovementScript : MonoBehaviour
{
    public float Sensitivity = 0.1f;
    public float maxSpeed = 1.0f;
    public float gravity = 30.0f;
    public float rotateIncrement = 90;

    public SteamVR_Action_Boolean rotatePress;

    public SteamVR_Action_Boolean movePress;
    public SteamVR_Action_Vector2 moveValue;

    private float speed = 0.0f;

    private CharacterController characterController;
    public Transform cameraRig;
    public Transform head;

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    
    void Start()
    {
        cameraRig = SteamVR_Render.Top().origin;
        head = SteamVR_Render.Top().head;
    }

    // Update is called once per frame
    void Update()
    {
     
        HandleHeight();
        CalculateMovement();
        SnapRotation();
        
    }

    public void HandleHeight()
    {
        //get the head in local space
        float headHeight = Mathf.Clamp(head.localPosition.y, 1, 2);
        characterController.height = headHeight;

        //cut in half
        Vector3 newCentre = Vector3.zero;
        newCentre.y = characterController.height / 2;
        newCentre.y += characterController.skinWidth;
        //movecapsule in local space
        newCentre.x = head.localPosition.x;
        newCentre.z = head.localPosition.z;



        //apply
        characterController.center = newCentre;
    }

    public void CalculateMovement()
    {
        Quaternion orientation = CalculateOrientation();
        Vector3 movement = Vector3.zero;

        //if not moving
        if (moveValue.axis.magnitude==0)
            speed = 0;
         
        
            speed += moveValue.axis.magnitude * Sensitivity;
            speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        

        movement += orientation * (speed * Vector3.forward);
        //gravity
        movement.y -= gravity * Time.deltaTime;

        //apply
        characterController.Move(movement*Time.deltaTime);
    }

    public void SnapRotation()
    {
        float snapValue = 0.0f;

        if (rotatePress.GetLastStateDown(SteamVR_Input_Sources.LeftHand))
            snapValue = -Mathf.Abs(rotateIncrement);
        if (rotatePress.GetLastStateDown(SteamVR_Input_Sources.RightHand))
            snapValue = Mathf.Abs(rotateIncrement);
        transform.RotateAround(head.position, Vector3.up, snapValue);
    }

    public Quaternion CalculateOrientation()
    {
        float rotation = Mathf.Atan2(moveValue.axis.x, moveValue.axis.y);
        rotation *= Mathf.Rad2Deg;

        //movement orientation
        Vector3 orientationEuler = new Vector3(0, head.eulerAngles.y+ rotation, 0);
        return Quaternion.Euler(orientationEuler);
    }
}

