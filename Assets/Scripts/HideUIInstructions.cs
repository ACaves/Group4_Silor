using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUIInstructions : MonoBehaviour
{
    public GameObject storyLineUI;
    public GameObject objectFoundCanvas;
    public static bool GameIsPaused = false;
    public GameObject crystal;

    // Start is called before the first frame update
    void Start()
    {
        crystal.SetActive(true);
        objectFoundCanvas.SetActive(false);
        storyLineUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>=15f)
        {
            crystal.SetActive(false);
            objectFoundCanvas.SetActive(true);
            Time.timeScale = 0F;
            Destroy(storyLineUI);
            GameIsPaused = false;
        }
    }
}
