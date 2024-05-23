using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetPoint : MonoBehaviour
{
    public Transform targetPoint;
    public float range = 100f;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            targetPoint.position = hit.point;
        }
        else
        {
            targetPoint.position = transform.position + transform.forward * range;
        }
    }
}
