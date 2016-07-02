using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintControl : MonoBehaviour
{
    float timer = 0.0f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<Text>().enabled == true)
        {
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                GetComponent<Text>().enabled = false;
                timer = 0.0f;
            }
        }
    }

    void ShowHint(string message)
    {
        gameObject.GetComponent<Text>().text = message;
        if (gameObject.GetComponent<Text>().enabled == false)
        {
            gameObject.GetComponent<Text>().enabled = true;
        }
    }
}
