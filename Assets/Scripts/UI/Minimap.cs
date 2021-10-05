using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public Transform target;
    public Transform targetCam;
    public Renderer miniMap;
    public Material floor1;
    public Material floor2;
    float defaultPosY;
    string locationNow;

    void Start()
    {
        defaultPosY = transform.position.y;
        locationNow = "lt1";
        StartCoroutine(work());
    }

    IEnumerator work() {
        while (true) {
            yield return new WaitForSeconds(0.1f);
            if(target.position.y <= 6.5f && locationNow == "lt2"){
                miniMap.material = floor1;
                locationNow = "lt1";
            }
            else if (target.position.y > 6.5f && locationNow == "lt1"){
                miniMap.material = floor2;
                locationNow = "lt2";
            }

            transform.position = new Vector3(target.position.x, defaultPosY, target.position.z);
            transform.rotation = Quaternion.Euler(90, targetCam.eulerAngles.y, 0);
        }
    }
}