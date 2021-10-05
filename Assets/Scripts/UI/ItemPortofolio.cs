using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPortofolio : MonoBehaviour
{
    public RawImage images;
    public TextMeshProUGUI textName;

    private string tname;
    private Texture ttexture;

    public void SetImage(Texture texture)
    {
        ttexture = texture;
        images.texture = texture;
    }

    public void SetName(string name)
    {
        tname = name;
        textName.text = name;
    }

    public void Setup(string name, Texture texture)
    {
        tname = name;
        ttexture = texture;

        images.texture = texture;
        textName.text = name;
    }

    public void OpenView()
    {
        FindObjectOfType<StoreUI>().porto.OpenView(tname, ttexture);
    }
}
