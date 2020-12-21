using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class SceneManagmentSystem : MonoBehaviour
{
    private void LoadMainMenu()
    {
        if (SteamVR_Actions.default_MainMenu.GetStateDown(SteamVR_Input_Sources.Any))//accesses input from steam vr 
        {
            SceneManager.LoadScene("Main Menu Scene");
        }
    }

   //SetUpBindings for Other Scenes Once Rahil Has Finished UI 


    //private void CharacterScene()
    //{

    //}

    //private void LoadLevelOne()
    //{

    //}

    //private void LoadLevelTwo()
    //{

    //}

    //private void LoadLevelThree()
    //{

    //}

    //private void LoadCreditScene()
    //{

    //}
}
