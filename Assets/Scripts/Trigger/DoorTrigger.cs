using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject PintuKanan;
    public GameObject PintuKiri;

    public Vector3 pintuKanan;
    public Vector3 pintuKiri;

    public Vector3 defaultKanan;
    public Vector3 defaultKiri;

    int player = 0;

    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player += 1;
            PintuKanan.transform.position += pintuKanan * Time.deltaTime;
            PintuKiri.transform.position += pintuKiri * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player -= 1;
            if(player <= 0)
            {
                StartCoroutine(Wait());
                PintuKanan.transform.position -= pintuKanan * Time.deltaTime;
                PintuKiri.transform.position -= pintuKiri * Time.deltaTime;
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
