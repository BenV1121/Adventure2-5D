using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Blade : MonoBehaviour
{
    public float damageOnContact = 1;

    private List<IDamageable> occupants = new List<IDamageable>();
    public GameObject hitsparks;

    private Rigidbody2D rb2D;

    public Text emiAmount;
    private int emiNumber;

    Emi emi;

    // Use this for initialization
    void Start ()
    {
        emiNumber = 0;
        SetEmiAmount();

        emi = (Emi)AssetDatabase.LoadAssetAtPath("Assets/Prefab/Drops/1Emi.prefab", typeof(Emi));
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "Objects")
        {
            Destroy(trigger.gameObject);
        }

        if (trigger.tag == "Enemy")
        {
            IDamageable target = trigger.gameObject.GetComponent<IDamageable>();
            target.TakeDamage(damageOnContact);
            occupants.Add(target);

            rb2D = trigger.gameObject.GetComponent<Rigidbody2D>();

            rb2D.AddForce(transform.up);

            Destroy(Instantiate(hitsparks, gameObject.transform.position, gameObject.transform.rotation), 1);
        }

        if (trigger.tag == "Emi")
        {
            emiNumber = emiNumber + emi.emiAmount;
            SetEmiAmount();
            Destroy(trigger.gameObject);
        }
    }
    void SetEmiAmount()
    {
        emiAmount.text = "x " + emiNumber.ToString();
    }
}
