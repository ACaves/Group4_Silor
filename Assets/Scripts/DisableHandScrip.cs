using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableHandScrip : MonoBehaviour
{
    public GameObject leftController;
    public GameObject rightController;


    public void DisableLeftController()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftController.SetActive(false);
        }
    }


    public void DisableRightController()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightController.SetActive(false);
        }
    }
}
