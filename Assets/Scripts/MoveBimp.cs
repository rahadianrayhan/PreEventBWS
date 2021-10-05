using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBimp : MonoBehaviour
{
    [SerializeField] Transform[] titikJalan;
    int id;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,titikJalan[id].position, speed * Time.deltaTime);
        Vector3 newDir = Vector3.RotateTowards(transform.forward,titikJalan[id].position - transform.position, Mathf.Lerp(0, 1, .5f * Time.deltaTime), 0);

        transform.rotation = Quaternion.LookRotation(newDir);

        if (Mathf.Abs(transform.position.x - titikJalan[id].position.x) <= 1 &&
           Mathf.Abs(transform.position.y - titikJalan[id].position.y) <= 1 &&
           Mathf.Abs(transform.position.z - titikJalan[id].position.z) <= 1)
        {
            id += 1;
        }
        if (id == titikJalan.Length)
        {
            id = 0;
        }
    }
}
