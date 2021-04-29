using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KrakenScript : MonoBehaviour
{

    //animator
   
    public float enemySpeed= 3f;
    public float maxEnemySpeed = 10f;
    public Transform targetPlayer;

    //speed variables
    public float accelerationTime = 60;
    private float minSpeed;
    private float time;

    //attack
    
    public float attackRange = 0.5f;
    
    public int attackDamage = 40;

    //waypoints
    public Transform[] wayPoints;
    private int randomSpot;

    public int health = 100;
    public int currentHealth;

    public int currentEnemyHealth;

    public GameObject krakenEnemy;

    public Animator krakenAnimator;
    
    public HealthScript healthScript;

    private void Start()
    {
          
        minSpeed = enemySpeed;
        time = 0;
        currentHealth = health;
        randomSpot = Random.Range(0, wayPoints.Length);
        StartCoroutine(EnemySpawnTime());
    }

    private void Update()
    {

        krakenEnemy.transform.LookAt(targetPlayer);
        krakenEnemy.transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, enemySpeed * Time.deltaTime);
        enemySpeed = Mathf.SmoothStep(minSpeed, maxEnemySpeed, time / accelerationTime);


    }


    void Attack()
    {
        krakenAnimator.SetTrigger("Attack");
        
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {

            krakenAnimator.Play("death");
        }
               


        //    //if (other.gameObject.tag=="Enemy")
        //    //{
        //    //    animator.Play("Attack");
        //    //}
        //}


        
  
    }

    //    void Die()
    //{


    //    //Destroy(this.gameObject);
    //    AddHealth(20);

    IEnumerator EnemySpawnTime()
    {
        yield return new WaitForSeconds(5);
        Instantiate(krakenEnemy, wayPoints[randomSpot].position, Quaternion.identity);
        transform.position -= transform.forward * enemySpeed * Time.deltaTime;
        time += Time.deltaTime;



    }

    public void AddHealth(int regainHealth)
    {
        currentHealth += regainHealth;
        healthScript.SetMaxHealth(regainHealth);
    }
}

