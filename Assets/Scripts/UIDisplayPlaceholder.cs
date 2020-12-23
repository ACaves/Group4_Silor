using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplayPlaceholder : MonoBehaviour
{
    public GameObject uiInstructions;

    private void Start()
    {
        uiInstructions.SetActive(true);
        StartCoroutine(HidUI());
    }

    IEnumerator HidUI()
    {
        yield return new WaitForSeconds(15);
        uiInstructions.SetActive(false);
    }
}
