using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class SceneManagementSystem : MonoBehaviour
{
    

    public void Update()
    {
       if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("escape key pressed");
            SceneManager.LoadScene("Main Menu Scene");
            
        }
           
    }

   

    public void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           Application.Quit();
        }
    }
}
