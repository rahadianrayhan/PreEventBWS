using UnityEngine;

public class PanelContainer : MonoBehaviour
{
    bool isOpen = false;
    public GameObject panel;
    public GameObject childPanel;
    [HideInInspector] public CharacterControl cc;
    [HideInInspector] public FeatureContainer fc;
    //[HideInInspector] public ObjectTrigger currentTrigger;

    private void Awake()
    {
        fc = GetComponentInParent<FeatureContainer>();
    }

    private void Start()
    {
        cc = GameManager.Instance.GetPlayerControl();
        ClosePanel();
    }

    void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePanel();
            }
        }
    }

    public void OpenPanel()
    {
        //currentTrigger.gameObject.SetActive(false);
        isOpen = true;
        cc.ControllerPause();
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        //currentTrigger.gameObject.SetActive(true);
        isOpen = false;
        cc.ControllerPause();
        panel.SetActive(false);
        if(fc != null)
            fc.ClosePanel();

        if(childPanel != null)
            childPanel.SetActive(false);
    }
}
