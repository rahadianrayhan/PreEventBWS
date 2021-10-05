using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookFollower : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Start()
    {
        target = Camera.main.transform;
    }

    private void Update()
    {
        Vector3 relativePos = (transform.position - target.position);
        relativePos.y = 0;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
