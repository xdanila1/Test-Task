using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _rangeSpawn;

    [SerializeField] private GameObject[] _mobs;


    private void Start()
    {
        foreach (var mob in _mobs)
        {
            float x = Random.Range(_rangeSpawn * -1, _rangeSpawn);
            float y = Random.Range(_rangeSpawn * -1, _rangeSpawn);
            Instantiate(mob, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
