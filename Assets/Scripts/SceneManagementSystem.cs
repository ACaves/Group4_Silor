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
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape key pressed");
            SceneManager.LoadScene("Main Menu Scene");
            
        }
           
    }


    public void LoadMainScene()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SceneManager.LoadScene("Main Menu Scene");
        }
    }

    public void LoadInstructionsScene()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SceneManager.LoadScene("Instructions Scene");
        }
    }

    public void LoadAboutSilor()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SceneManager.LoadScene("About Silor Scene");
        }
    }

    public void LoadSceneOne()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SceneManager.LoadScene("Level 1 GreyBox");
        }
    }

    public void LoadSceneTwo()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SceneManager.LoadScene("Level 2");
        }
    }

    public void LoadSceneThree()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SceneManager.LoadScene("Level 3");
        }
    }

    public void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           Application.Quit();
        }
    }
}
