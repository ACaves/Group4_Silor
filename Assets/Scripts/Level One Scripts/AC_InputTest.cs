using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AC_InputTest : MonoBehaviour
{
    public SteamVR_ActionSet a_defaultActionSet;
    public SteamVR_Action_Boolean a_BooleanAction;

    private void Update()
    {
        if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.LeftHand))
        {
            Debug.Log("shooter trigger pressed");
        }
    }
}
