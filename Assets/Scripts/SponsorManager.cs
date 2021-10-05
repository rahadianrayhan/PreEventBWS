using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponsorManager : MonoBehaviour
{
    [SerializeField] GameObject[] balon;
    [SerializeField] Texture[] textures;

    Renderer renderer;
    private int randomIndex;


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < balon.Length; i++)
        {
            renderer = balon[i].GetComponent<Renderer>();
            ChangeTextureBalon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTextureBalon()
    {
        randomIndex = Random.Range(0, textures.Length);
        renderer.material.mainTexture = textures[randomIndex];
    }
}
