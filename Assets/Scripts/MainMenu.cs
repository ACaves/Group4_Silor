using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class MainMenu : MonoBehaviour
{

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void loadSteamVRLevel(string sceneName)
    {
        SteamVR_LoadLevel.Begin(sceneName);
    }
}
