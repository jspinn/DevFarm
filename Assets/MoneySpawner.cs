using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{

    [SerializeField] private GameObject coin;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMoney", spawnDelay, spawnDelay);
    }

    public void SpawnMoney() {
        offset[0] = Random.Range(-1.0f, 1.0f);
        Instantiate(coin, transform.position + offset, transform.rotation);
    }

    public void SetDelay(float delay) {
        spawnDelay = delay;
    }
}
