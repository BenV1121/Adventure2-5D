using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageOnContact = 1;

    private List<IDamageable> occupants = new List<IDamageable>();
    public GameObject hitsparks;

    public Rigidbody rb;
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider trigger)
    {
        if(trigger.tag == "Player")
        {
            IDamageable target = trigger.gameObject.GetComponent<IDamageable>();
            target.TakeDamage(damageOnContact);
            occupants.Add(target);

            rb = trigger.gameObject.GetComponent<Rigidbody>();

            rb.isKinematic = false;
            rb.AddForce(transform.forward * 500);

            Destroy(Instantiate(hitsparks, gameObject.transform.position, gameObject.transform.rotation), 1);
        }
    }
}
