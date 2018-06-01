using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emi : MonoBehaviour
{
    PlayerController player;

    public int emiAmount;

    //Emies are the currency of this game
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject.GetComponent<PlayerController>();

            player.emiNumber += emiAmount;
            player.GetComponent<PlayerController>().SetEmiAmount();

            Destroy(gameObject);
        }
    }
}
