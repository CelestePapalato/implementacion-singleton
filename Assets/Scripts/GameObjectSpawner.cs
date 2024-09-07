using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject toSpawn;
    [SerializeField]
    float minTime;
    [SerializeField]
    float maxTime;

    private void Start()
    {
        CalculateNextSpawn();
    }

    private void CalculateNextSpawn()
    {
        float r = Random.Range(minTime, maxTime);
        Invoke(nameof(Spawn), r);
    }

    private void Spawn()
    {
        Instantiate(toSpawn, transform.position, Quaternion.identity);
        CalculateNextSpawn();
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }

}
