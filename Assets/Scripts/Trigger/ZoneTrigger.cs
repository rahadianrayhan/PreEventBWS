using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    [Header("Toggle Object on Trigger")]
    public GameObject[] objectsToToggle;
    public bool[] invertObjectState;
    public bool objectToToggleDefaultActive = false;
    [Header("Send Message on Trigger")]
    public GameObject objectToSendMessage;
    public string messageToSendOnTriggerEnter;
    public string messageToSendOnTriggerExit;

    [Header("Check Entertaintment")]
    public bool isEntertaintment = false;

    void Start()
    {
        int i = 0;
        foreach (GameObject objectToToggle in objectsToToggle)
        {
            objectToToggle.SetActive(invertObjectState[i] ? !objectToToggleDefaultActive : objectToToggleDefaultActive);
            i++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int i = 0;
            foreach (GameObject objectToToggle in objectsToToggle)
            {
                objectToToggle.SetActive(invertObjectState[i] ? false : true);
                i++;
            }

            if (objectToSendMessage != null)
            {
                objectToSendMessage.SetActive(true);
                if (messageToSendOnTriggerEnter != "")
                {
                    objectToSendMessage.SendMessage(messageToSendOnTriggerEnter);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            int i = 0;
            foreach (GameObject objectToToggle in objectsToToggle)
            {
                objectToToggle.SetActive(invertObjectState[i] ? true : false);
                i++;
            }

            if (objectToSendMessage != null)
            {
                if (messageToSendOnTriggerExit != "")
                {
                    objectToSendMessage.SendMessage(messageToSendOnTriggerExit);
                }
            }
        }
    }
}
