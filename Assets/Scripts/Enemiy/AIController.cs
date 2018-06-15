using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour, IDamageable
{
    public float health = 3;

    public Transform player;
    Vector3 destination;

    NavMeshAgent agent;

    private Rigidbody rb;

    float kinematicTimer = .1f;
    float kTimeReset = .1f;

    float AttackTimer;

    Transform attackBox;

    public void TakeDamage(float damageDealt)
    {
        health -= damageDealt;

        if (health <= 0)
            Death();
    }

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        rb = GetComponent<Rigidbody>();
        attackBox = gameObject.transform.GetChild(1);

        attackBox.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        destination = player.position;
        agent.destination = destination;

        if(rb.isKinematic == false)
        { 
            kinematicTimer -= Time.deltaTime;
        }
        if (kinematicTimer <= 0)
            ResetKTimer();
	}

    void Death()
    {
        Destroy(gameObject);
    }

    void ResetKTimer()
    {
        rb.isKinematic = true;
        kinematicTimer = kTimeReset;
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "Player")
        {
            attackBox.gameObject.SetActive(true);

        }
    }
}
