using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public static Loading Instance;
    public Transform loadingImage;
    public GameObject loadingBg;
    bool loading = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        StopLoading();
    }

    void Update()
    {
        if (loading)
        {
            loadingImage.Rotate(Vector3.up * Time.deltaTime * 360f);
        }
    }

    public void StartLoading() {
        loading = true;
        loadingBg.SetActive(true);
    }

    public void StopLoading() {
        loading = false;
        loadingBg.SetActive(false);
    }
}
