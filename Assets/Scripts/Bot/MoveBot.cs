using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBot : MonoBehaviour
{
    [Header("Moving Direction")]
    [SerializeField] Transform[] titikJalan;
    int id;

    [Header("Open Target")]
    [SerializeField] GameObject booth;
    [SerializeField] GameObject target;

    [Header("Info Bot")]
    public float speed = -1f;
    public float speedAnim = 0.2f;

    public bool conversation;

    Animator animator;
    CharacterControl cc;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = FindObjectOfType<CharacterControl>();
        animator.SetFloat("Speed", speedAnim);
        conversation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (conversation)
        {
            Ngobrol();
        }
        if (!conversation)
        {
            BotWalk();
        } 
    }

    private void BotWalk()
    {
        animator.SetFloat("Speed", 0.2f);
        transform.position = Vector3.MoveTowards(transform.position, titikJalan[id].position, speed * Time.deltaTime);
        Vector3 newDir = Vector3.RotateTowards(transform.forward, titikJalan[id].position - transform.position, Time.deltaTime, 0);

        transform.rotation = Quaternion.LookRotation(newDir);

        if (Mathf.Abs(transform.position.x - titikJalan[id].position.x) <= 1 &&
           Mathf.Abs(transform.position.y - titikJalan[id].position.y) <= 1 &&
           Mathf.Abs(transform.position.z - titikJalan[id].position.z) <= 1)
        {
            id += 1;
        }
        if (id == titikJalan.Length)
        {
            id = 0;
        }
    }

    private void Ngobrol()
    {
        Vector3 a = new Vector3(target.transform.position.x, 0, target.transform.position.z);
        Vector3 targetDirection = a - transform.position;
        Vector3 Dir = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(Dir);
        animator.SetFloat("Speed", 0);
    }

    public void setActive(GameObject obj)
    {
        obj.SetActive(true);
        cc.ControllerPause();
        conversation = true;
    }

    public void setNonActive(GameObject obj)
    {
        obj.SetActive(false);
        cc.ControllerPause();
        conversation = false;
    }

    private void OnMouseUp()
    {
        float a = Vector3.Distance(target.transform.position, transform.position);
        Mathf.Abs(a);

        if(a < 3)
        {
            if (!conversation)
            {
                setActive(booth);
            }
            else
            {
                setNonActive(booth);
            }
        }    
    }
}
