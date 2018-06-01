using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    static Animator anim;
    public bool stillInAttackFrame;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
	}
}
