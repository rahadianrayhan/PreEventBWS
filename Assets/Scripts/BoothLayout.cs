using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothLayout : MonoBehaviour
{
    public Layout layout;

    private int goldCount;
    private int silverCount;

    private void Start()
    {
        goldCount = layout.gold.Count;
        silverCount = layout.silver.Count;

        Debug.Log("Active Euy ");
    }

    
}

[System.Serializable]
public class Layout
{
    public GameObject platinum;
    public List<GameObject> gold;
    public List<GameObject> silver;
}