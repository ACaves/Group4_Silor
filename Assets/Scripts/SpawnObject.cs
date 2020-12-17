using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnObject : MonoBehaviour
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
        while (enemyCount < 25)
        {
            xPos = Random.Range(10, 35);
            zPos = Random.Range(5, 10);
            yPos = Random.Range(0, 4);
            Instantiate(nymphPrefab, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5);
            enemyCount += 1;

        }

        if (enemyCount > 25)
        {
            SceneManager.LoadScene("Main Menu Scene");
        }
    }

   


   
}
