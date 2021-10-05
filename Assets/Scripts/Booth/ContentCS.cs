using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentCS : MonoBehaviour
{
    private string phone;

    private ChatUI chatUI;
    private void Awake()
    {
        chatUI = FindObjectOfType<ChatUI>();
    }

    public void SetPhone(string _phone, bool isCatering)
    {
        phone = _phone;

        chatUI.IsCatering(isCatering);
        chatUI.Number = _phone;
    }
}
