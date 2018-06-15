using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOffCliff : MonoBehaviour
{
    PlayerController playerController;
    private Rigidbody playerRB;

	// Use this for initialization
	void Start ()
    {
        playerController = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "Player")
        {
            playerRB = trigger.gameObject.GetComponent<Rigidbody>();

            playerRB.isKinematic = false;
            playerController.nMA.enabled = false;
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.tag == "Player")
        {
            playerRB = trigger.gameObject.GetComponent<Rigidbody>();

            playerRB.isKinematic = true;
            playerController.nMA.enabled = true;
        }
    }
}
