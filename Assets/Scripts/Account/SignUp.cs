using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SignUp : MonoBehaviour
{
    #region attribute

    private string username = "";
    private string email = "";
    private string password = "";
    private date dob;
    private string t_dob;
    private string job = "";
    private string domisili = "";
    private string phone = "";
    private string status = "";
    private string wedd_plan;
    private date wedd_date;
    private string t_wedd_date;

    #endregion

    #region initial

    public TMP_InputField in_name;
    public TMP_InputField in_email;
    public TMP_InputField in_password;
    public TMP_InputField in_job;
    public TMP_InputField in_domisili;
    public TMP_InputField in_phone;

    public ToggleGroup tg_status;
    public ToggleGroup tg_weddplan;

    public CalendarController c_dob;
    public CalendarController c_date_plan;
    #endregion

    public TextMeshProUGUI datePlanText;

    private void Start()
    {
        TG_StatusUpdate();
        TG_WeddUpdate();
    }

    public void TG_StatusUpdate()
    {
        foreach (Toggle t in tg_status.ActiveToggles())
        {
            if (t.isOn == true)
            {
                status = t.GetComponentInChildren<Text>().text;
                Debug.Log(status + " | " + t.name);
                break;
            }
        }
    }

    public void TG_WeddUpdate()
    {
        foreach (Toggle t in tg_weddplan.ActiveToggles())
        {
            if (t.isOn == true)
            {
                wedd_plan = t.GetComponentInChildren<Text>().text;
                Debug.Log(wedd_plan);

                if(wedd_plan == "Ya")
                {
                    c_date_plan.gameObject.SetActive(true);
                    c_date_plan.ShowCalendar(datePlanText);
                }
                else
                {
                    c_date_plan.gameObject.SetActive(false);
                    c_date_plan.HideCalendar();
                }

                break;
            }
        }
    }

    public void NameUpdate()
    {
        username = in_name.text;
    }

    public void EmailUpdate()
    {
        email = in_email.text;
    }

    public void PwUpdate()
    {
        password = in_password.text;
    }

    public void JobUpdate()
    {
        job = in_job.text;
    }

    public void DomUpdate()
    {
        domisili = in_domisili.text;
    }

    public void PhoneUpdate()
    {
        phone = in_phone.text;
    }

    public void DOBUpdate()
    {
        t_dob = c_dob.GetDate();
        Debug.Log(t_dob);
    }

    public void WeddPlanUpdate()
    {
        t_wedd_date = c_date_plan.GetDate();
        Debug.Log(t_wedd_date);
    }

    public void Register()
    {
        Debug.Log(
            username + "\n" +
            email + "\n" +
            password + "\n" +
            job + "\n" +
            dob.ToString() + "\n" +
            domisili + "\n" +
            username + "\n" +
            phone + "\n" +
            status + "\n" +
            wedd_plan + "\n" +
            wedd_date.ToString()
            );
    }
}