using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public CharacterControl cc;
    Transform spawnTrans;
    SceneFader fade;

    private Camera cam;
    public Placement place;

    private void Awake()
    {
        //spawnTrans = this.transform;
        fade = FindObjectOfType<SceneFader>();
        cam = Camera.main;
    }

    public void reSpawn(int _type)
    {
        fade.StartFade();

        switch (_type)
        {
            case 3:
                spawnTrans = place.silver;
                break;
            case 2:
                spawnTrans = place.gold;
                break;
            case 1:
                spawnTrans = place.platinum;
                break;
            default:
                spawnTrans = place.platinum;
                break;
        }

        cc.transform.position = spawnTrans.position;
        cc.transform.localEulerAngles = spawnTrans.localEulerAngles;

        float yRot = spawnTrans.localEulerAngles.y;
        ThirdPersonOrbitCamBasic camScript = cam.GetComponent<ThirdPersonOrbitCamBasic>();
        camScript.SetH = yRot;
        camScript.SetV = 0;
    }
}
