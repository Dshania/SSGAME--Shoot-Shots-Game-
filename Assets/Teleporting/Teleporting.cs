using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            player.transform.position = new Vector3(Random.Range(-240, 240), 10, Random.Range(-240, 240));
        }
    }
}
