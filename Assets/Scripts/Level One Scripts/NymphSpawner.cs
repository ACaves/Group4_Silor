using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NymphSpawner : MonoBehaviour
{
    public GameObject krakenEnemyPrefab;
   
    public Transform targetPlayer;
    public float enemySpeed = 2f;


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
            krakenEnemyPrefab.SetActive(true);
            xPos = Random.Range(20, 25);
            zPos = Random.Range(5, 6);
            yPos = Random.Range(0, 4);
            Instantiate(krakenEnemyPrefab, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(10);
            enemyCount += 1;

        }

        if (enemyCount > 10)
        {
            SceneManager.LoadScene("Main Menu Scene");
        }
    }

    private void Update()
    {
        transform.LookAt(targetPlayer);
        Quaternion targetRotation = Quaternion.LookRotation(targetPlayer.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        transform.position += transform.forward * 1f * Time.deltaTime;

        //transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, enemySpeed * Time.deltaTime);
    }


}
