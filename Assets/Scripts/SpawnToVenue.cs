using UnityEngine;

public class SpawnToVenue : MonoBehaviour
{
    public Transform gate;
    public Transform[] booth;

    private Transform player;

    [SerializeField] private LandingPage lp;

    ThirdPersonOrbitCamBasic camScript;

    private void Start()
    {
        player = GameManager.Instance.GetPlayer();

        
        camScript = Camera.main.GetComponent<ThirdPersonOrbitCamBasic>();
    }

    public void SpawnToGate()
    {
        player.localPosition = gate.localPosition;
        player.localEulerAngles = gate.localEulerAngles;

        lp.CloseLandingPage();
        LandscapeMode();
    }

    public void SpawnToBooth(int id_spawner)
    {
        player.localPosition = booth[id_spawner].localPosition;
        player.localEulerAngles = gate.localEulerAngles;

        float yRot = booth[id_spawner].localEulerAngles.y;
        camScript.SetH = yRot;
        camScript.SetV = 0;

        lp.CloseLandingPage();
        LandscapeMode();
    }

    public void LandscapeMode()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
