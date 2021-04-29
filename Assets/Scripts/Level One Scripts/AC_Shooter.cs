using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AC_Shooter : MonoBehaviour
{   // Start is called before the first frame update
    public SteamVR_ActionSet orbActions;

    public GameObject orbPrefab;

    public Rigidbody orbRigidbody;

    public Transform orbOrigin;

    public float orbSpeed = 200f;

    public int attackDamage = 40;

    public LayerMask enemyLayers;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    public int maxHealth = 100;
    public int currentHealth;
    public int regainHealth;

    public Animator animator;

    public HealthScript healthScript;


    void Start()
    {
        currentHealth = maxHealth;
        healthScript.SetMaxHealth(maxHealth);
        orbActions.Activate(SteamVR_Input_Sources.Any, 0, true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.Any))
            {
                orbPrefab.SetActive(true);
                Fire();
                Debug.Log("trigger pulled");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);

        if (other.gameObject.tag == "Player")
        {
            TakeDamage(20);
        }
    }

    void Fire()
    {
        Rigidbody projectileInstance;
        projectileInstance = Instantiate(orbRigidbody, orbOrigin.position, orbOrigin.rotation) as Rigidbody;
        projectileInstance.AddForce(orbOrigin.forward * orbSpeed);
        Debug.Log("Cloned orb");

        // You can add shader graph here 


    }


    void SetInnactive()
    {
        Destroy(gameObject, 10f);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthScript.SetMaxHealth(currentHealth);
    }





}