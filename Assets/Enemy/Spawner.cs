using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject targetPrefab;
    void Awake()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Vector3 randomSpawn = new Vector3(Random.Range(-240, 240), 10, Random.Range(-240, 240));
                    Instantiate(targetPrefab, randomSpawn, Quaternion.identity);
                }
               

            }
        }
       
    }
}
