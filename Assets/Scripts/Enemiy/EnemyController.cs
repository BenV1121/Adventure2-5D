using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public float health = 3;

    public Transform[] patrolPoints;
    public int pointIdx;

    public Transform target;
    public float chaseRange;

    public float speed = 2;

    float step;

    public void TakeDamage(float damageDealt)
    {
        health -= damageDealt;

        if (health <= 0)
            Death();
    }

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        step = speed * Time.deltaTime;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if(distanceToTarget < chaseRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[pointIdx].position, step);
            Vector2.Distance(transform.position, patrolPoints[pointIdx].position);

            if (step >= Vector2.Distance(transform.position, patrolPoints[pointIdx].position))
            {
                pointIdx = (pointIdx + 1) % patrolPoints.Length;
            }
        }
	}

    void Death()
    {
        Destroy(gameObject);
    }
}
