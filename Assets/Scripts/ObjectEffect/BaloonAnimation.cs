using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonAnimation : MonoBehaviour
{
    public Vector3 swayAxis;
    public float swayAmplitute = 10f;
    public float swaySpeed = 10f;
    void Start()
    {
        initRot = transform.localRotation.eulerAngles;
        targetRot = initRot + swayAxis * swayAmplitute;
    }
    Vector3 initRot;
    Vector3 targetRot;
    float t = 0f;

    void Update()
    {
        
        if (t>Random.Range(2f,7f))
        {
            targetRot = initRot + new Vector3(Random.Range(-swayAxis.x,swayAxis.x), Random.Range(-swayAxis.y, swayAxis.y), Random.Range(-swayAxis.z, swayAxis.z)) * swayAmplitute;
            t = 0f;
        }
        else
        {
            t += Time.deltaTime;
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(targetRot), Time.deltaTime * swaySpeed);
        }
    }
}
