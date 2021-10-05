using UnityEngine;
using TMPro;
using System.Collections;

public class GuestUI : MonoBehaviour
{
    public TextMeshProUGUI confirmText;
    private PanelContainer pc;

    private void Awake()
    {
        pc = GetComponent<PanelContainer>();
    }

    public void Confirm()
    {
        confirmText.text = "Terimakasih, anda akan segera kami hubungi.";
        StartCoroutine(ConfirmText());
    }

    IEnumerator ConfirmText()
    {
        yield return new WaitForSeconds(0.5f);
        pc.ClosePanel();
        yield return new WaitForSeconds(0.1f);
        confirmText.text = "";
    }
}
