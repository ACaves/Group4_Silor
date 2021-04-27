using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KrakenScript : MonoBehaviour
{

    //animator
    public Animator animator;

    public float enemySpeed= 1f;
    public float maxEnemySpeed = 10f;
    public Transform targetPlayer;

    //speed variables
    public float accelerationTime = 60;
    private float minSpeed;
    private float time;

  

    //attack
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public int attackDamage = 40;

    //waypoints
    public Transform[] wayPoints;
    private int randomSpot;

    public int maxHealth = 100;
    public int currentHealth;

    public GameObject krakenEnemy;
    
    public HealthScript healthScript;

    private void Start()
    {
        
        minSpeed = enemySpeed;
        time = 0;
        currentHealth = maxHealth;
        randomSpot = Random.Range(0, wayPoints.Length);
        StartCoroutine(EnemySpawnTime());
    }


    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider[] hitEnemies=Physics.OverlapSphere(attackPoint.position, attackRange, playerLayers);
        foreach (Collider enemy in hitEnemies)
        {
            TakeDamage(attackDamage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        Attack();

    }
    private void Update()
    {

        transform.LookAt(targetPlayer);
        transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, enemySpeed * Time.deltaTime);
        enemySpeed = Mathf.SmoothStep(minSpeed, maxEnemySpeed, time / accelerationTime);

        
    }

    IEnumerator EnemySpawnTime()
    {
        yield return new WaitForSeconds(3);
        Instantiate(krakenEnemy, wayPoints[randomSpot].position, Quaternion.identity);
        transform.position -= transform.forward * enemySpeed * Time.deltaTime;
        time += Time.deltaTime;



    }

    public void TakeDamage(int damage)
    {
        currentEnemyHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentEnemyHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //die animation
        animator.SetBool("IsDead", true);
        this.enabled = false;
        GetComponent<Collider>().enabled = false;

        AddHealth(20);
    }

    public void AddHealth(int regainHealth)
    {
        currentHealth += regainHealth;
        healthScript.SetMaxHealth(regainHealth);
    }
}

