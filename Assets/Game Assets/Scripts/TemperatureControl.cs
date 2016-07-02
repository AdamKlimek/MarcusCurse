using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TemperatureControl : MonoBehaviour
{
    public float Temperature;
    public Image TemperatureBar;
    float MaxTemperature = 20;
    float EndTime = 0.0f;
    public static bool isCollision = false;
    float ActuallyTime = 0.0f;
    GameObject hint;
    bool show = false;
    GameObject Display;
    float timer;
    public float difficult;
    public AudioClip hurt;
    GameObject dif;
    // Use this for initialization
    void Start()
    {
        Display = GameObject.Find("Timer");
        hint = GameObject.FindGameObjectWithTag("Hint");
        Temperature = 20;
        dif = GameObject.Find("diff");
        difficult = dif.GetComponent<difficult>().Di;
        timer = difficult;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        checkTemperature();

        ActuallyTime += Time.deltaTime;

        if (ActuallyTime >= difficult)
        {
            Display.GetComponent<Text>().text = "0";
            timer = difficult;
           EndTime += Time.deltaTime;
            if (isCollision == false)
            {
                if (EndTime >= 5.0f)
                {
                    if (show == false)
                    {
                        hint.SendMessage("ShowHint", "I must find the way to turn on a heating unless I will freeze to death.");
                        show = true;
                    }
                    DecreaseTemperature();
                    EndTime = 0.0f;
                }
            }
            else
            {
                if (EndTime >=  2.0f)
                {
                    if (show == true)
                    {
                        hint.SendMessage("ShowHint", "Ufff...the temperature is increasing. I have some time to find a way to escape from this building.");
                        show = false;
                    }
                    IncreaseTemperature();
                    EndTime = 0.0f;
                }
            }
        }
        else
        {

            Display.GetComponent<Text>().text =  timer.ToString();
            timer -= Time.deltaTime;
        }
    }

    void IncreaseTemperature()
    {
        if (Temperature / MaxTemperature < 1)
        {
            Temperature++;
        }
        else if (Temperature / MaxTemperature == 1)
        {
            Temperature = 20.0f;
            isCollision = false;
            ActuallyTime = 0.0f;
        }

    }

    void DecreaseTemperature()
    {
        if(Temperature/MaxTemperature > 0)
        {
            Temperature--;
        }
        else
        {
            Temperature = 0.0f;
            if (gameObject.GetComponent<HealthControl>().HealthPoints > 0)
            {
                GetComponent<AudioSource>().PlayOneShot(hurt);
                gameObject.GetComponent<HealthControl>().HealthPoints -= 5;
                if (gameObject.GetComponent<HealthControl>().HealthPoints == 0)
                {
                    gameObject.GetComponent<HealthControl>().HealthPoints = 0;
                    gameObject.SendMessage("Dead");
                }
            }
        }
    }

    void checkTemperature()
    {
        TemperatureBar.rectTransform.localScale = new Vector3(Temperature / MaxTemperature, TemperatureBar.rectTransform.localScale.y, TemperatureBar.rectTransform.localScale.z);
    }
}
