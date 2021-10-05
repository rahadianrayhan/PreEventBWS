using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationManager : MonoBehaviour
{
    public Info[] info;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setActive(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void setNonActive(GameObject obj)
    {
        obj.SetActive(false);
    }
}
