using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]

public class EqupmentManager : MonoBehaviour
{
    private Canvas Equipment;
   // public Image crosshair;
    public GameObject hero;

	// Use this for initialization
	void Start ()
    {
       Equipment =  (Canvas)GetComponent<Canvas>();
       Equipment.enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            Equipment.enabled = !Equipment.enabled;
        }

        if(Input.GetKeyUp(KeyCode.Escape) && Equipment.enabled == true)
        {
            Equipment.enabled = false;
        }

        if (Equipment.enabled == true)
        {
            hero.GetComponentInChildren<Hero>().enabled = false;
            hero.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            hero.GetComponentInChildren<Hero>().enabled = true;
            hero.GetComponent<FirstPersonController>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }

}
