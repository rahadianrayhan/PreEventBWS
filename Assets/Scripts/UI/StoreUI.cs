using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public Transform parrent;
    public GameObject tamplateItem;

    public ItemPortofolioView porto;
    public Texture thum;

    [SerializeField] private List<Texture> texture = new List<Texture>();

    private void Start()
    {
       // GenerateItem("satu ", thum);
       // GenerateItem("Dua ", thum);
       // GenerateItem("Tiga ", thum);
       // GenerateItem("Empat ", thum);
       // GenerateItem("LIma ", thum);
       // GenerateItem("Enam ", thum);

        for(int i=0; i<texture.Count; i++)
        {
            GenerateItem("Katalog " + (i + 1), texture[i]);
        }
    }

    public void GenerateItem(string _name, Texture _texture)
    {
        GameObject item = Instantiate(tamplateItem, parrent);
        item.GetComponent<ItemPortofolio>().Setup(_name, _texture);
    }

    public ItemPortofolioView GetView()
    {
        return porto;
    }

    public void OpenLink(string link) 
    {
        if (GameManager.Instance.isWeb)
        {
#if !UNITY_EDITOR
		//WebInteraction.OpenWebsite(link);
#endif
        }
        else
        {
            Debug.Log("open " + link);
            Application.OpenURL(link);
        }
        
    }
}
