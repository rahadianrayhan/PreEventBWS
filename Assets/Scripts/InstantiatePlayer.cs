using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{
    public int masukanNoChar;
    public GameObject[] prefab;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        SetChar(masukanNoChar);
    }

    public void SetChar(int i)
    {
        var player = Instantiate(prefab[i], parent.transform.position, Quaternion.identity);
        player.transform.parent = gameObject.transform;
        var anim = player.GetComponent<Animator>().avatar;
        parent.GetComponentInChildren<Animator>().avatar = anim;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
