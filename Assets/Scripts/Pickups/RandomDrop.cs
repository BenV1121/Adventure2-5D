using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour
{
    int spawnIdx;
    public List<GameObject> drops;

    void OnTriggerEnter(Collider trigger)
    {
        spawnIdx = Random.Range(0, drops.Count);
        Instantiate(drops[spawnIdx], gameObject.transform.position, gameObject.transform.rotation);
    }
}
