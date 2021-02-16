using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NymphSpawner : MonoBehaviour
{
    public GameObject nymphPrefab;
  

    public int xPos;
    public int zPos;
    public int yPos;
    public int enemyCount;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            nymphPrefab.SetActive(true);
            xPos = Random.Range(20, 25);
            zPos = Random.Range(5, 6);
            yPos = Random.Range(0, 4);
            Instantiate(nymphPrefab, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(10);
            enemyCount += 1;

        }

        if (enemyCount > 10)
        {
            SceneManager.LoadScene("Main Menu Scene");
        }
    }

    


}
