using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AC_LocomotionScript : MonoBehaviour
{
    public float m_Gravity = 30.0f;
    public float m_sensitivity = 0.1f;
    public float m_MaxSpeed = 1.0f;
    public float m_RotateIncrement=90;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;
    public SteamVR_Action_Boolean m_RotatePress = null;

    private float m_speed = 0.0f;

    private CharacterController m_ChartacterController = null;
    public Transform m_CameraRig = null;
    public Transform m_Head = null;
    public Transform headHeight = null;

    private void Awake()
    {
        m_ChartacterController = GetComponent<CharacterController>();
    }

    public void Start()
    {
     
        m_CameraRig = SteamVR_Render.Top().origin; //camera is on the player controller
        m_Head = SteamVR_Render.Top().head;
    }

    private void Update()
    {
       
        HandleHeight();
        CalculateMovement();
        SnapRotation();
        
    }

    private void HandleHeight() //this method handles the player within the space and how they move within that area
    {
        //get the head in local space
        float headHeight = Mathf.Clamp(m_Head.localPosition.y, 1, 2);
        m_ChartacterController.height = headHeight;

        //cut in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_ChartacterController.height / 2;
        newCenter.y += m_ChartacterController.skinWidth;

        //Move capsule local space
        newCenter.x = m_Head.localPosition.x;
        newCenter.z = m_Head.localPosition.z;



        //apply
        m_ChartacterController.center = newCenter;

    }

    private void CalculateMovement()// this methos calculates the movement of the player and clamps the speed so that the player does not go too fast
    {
        //movement orientation
        Vector3 orientationEuler = new Vector3(0, m_Head.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;


        //if not moving
        if (m_MovePress.GetStateUp(SteamVR_Input_Sources.Any))
        {
            m_speed = 0;
        }

        //if button pressed
        if (m_MovePress.state)
        {
            m_MaxSpeed += m_MoveValue.axis.y * m_sensitivity;
            m_speed = Mathf.Clamp(m_speed, -m_MaxSpeed, m_MaxSpeed);

            //add speed and clamp speed

            movement += orientation * (m_speed * Vector3.forward) ;
        }
        // gravity

        movement.y -= m_Gravity * Time.deltaTime;
        //apply
        m_ChartacterController.Move(movement*Time.deltaTime);
    }

   private void SnapRotation()
    {
        float snapValue = 0.0f;

        if (m_RotatePress.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            snapValue = -Mathf.Abs(m_RotateIncrement);
        }

        if (m_RotatePress.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            snapValue = Mathf.Abs(m_RotateIncrement);
        }

        transform.RotateAround(m_Head.position, Vector3.up, snapValue);
    }

}
