using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public AudioClip beep;
    public GameObject Dif;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<AudioSource>().PlayOneShot(beep);
        Color col = GetComponent<Image>().color;
        col.a = 0.5f;
        GetComponent<Image>().color = col;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color col = GetComponent<Image>().color;
        col.a = 1;
        GetComponent<Image>().color = col;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Input.GetButtonUp("LPM") == true)
        {
            GetComponent<AudioSource>().PlayOneShot(beep);
        }


        if(gameObject.name == "NewGame")
        {
            DontDestroyOnLoad(Dif);
            SceneManager.LoadScene(1);
        }
        else if(gameObject.name == "Instructions")
        {
            Menu.page = "Instructions";
            Color col = GetComponent<Image>().color;
            col.a = 1;
            GetComponent<Image>().color = col;
        }
        else if(gameObject.name == "Exit")
        {
            Application.Quit();
        }
        else if(gameObject.name == "Return")
        {
            if (Menu.page == "options")
            {
                Menu.page = "main";
            }
            else if(Menu.page == "Instructions")
            {
                Menu.page = "options";
            }
            else if (Menu.page == "difficult")
            {
                Menu.page = "options";
            }
            else if (Menu.page == "credits")
            {
                Menu.page = "options";
            }
            Color col = GetComponent<Image>().color;
            col.a = 1;
            GetComponent<Image>().color = col;
        }
        else if (gameObject.name == "Options")
        {
            Menu.page = "options";
            Color col = GetComponent<Image>().color;
            col.a = 1;
            GetComponent<Image>().color = col;
        }
        else if (gameObject.name == "Difficult")
        {
            Menu.page = "difficult";
            Color col = GetComponent<Image>().color;
            col.a = 1;
            GetComponent<Image>().color = col;
        }
        else if (gameObject.name == "Easy")
        {
           
            Dif.SendMessage("SetDifficult", 300.0f);
            Color col = GetComponent<Image>().color;
            col.a = 1;
            col.r = 0;
            col.g = 1;
            col.b = 65 / 255;
            if (GameObject.Find("Hard").GetComponent<Image>().color != Color.white || GameObject.Find("Medium").GetComponent<Image>().color != Color.white)
            {
                GameObject.Find("Hard").GetComponent<Image>().color = Color.white;
                GameObject.Find("Medium").GetComponent<Image>().color = Color.white;
            }
            GetComponent<Image>().color = col;
        }
        else if (gameObject.name == "Medium")
        {
            
            Dif.SendMessage("SetDifficult", 180.0f);
            Color col = GetComponent<Image>().color;
            col.a = 1;
            col.r = 0;
            col.g = 1;
            col.b = 65 / 255;
            if (GameObject.Find("Hard").GetComponent<Image>().color != Color.white || GameObject.Find("Easy").GetComponent<Image>().color != Color.white)
            {
                GameObject.Find("Hard").GetComponent<Image>().color = Color.white;
                GameObject.Find("Easy").GetComponent<Image>().color = Color.white;
            }
            GetComponent<Image>().color = col;
        }
        else if (gameObject.name == "Hard")
        {
           
            Dif.SendMessage("SetDifficult", 60.0f);
            Color col = GetComponent<Image>().color;
            col.a = 1;
            col.r = 0;
            col.g = 1;
            col.b = 65 / 255;
            if(GameObject.Find("Medium").GetComponent<Image>().color  != Color.white || GameObject.Find("Easy").GetComponent<Image>().color != Color.white)
            {
                GameObject.Find("Medium").GetComponent<Image>().color = Color.white;
                GameObject.Find("Easy").GetComponent<Image>().color = Color.white;
            }
            GetComponent<Image>().color = col;
        }
        else if (gameObject.name == "Credits")
        {
            Menu.page = "credits";
            Color col = GetComponent<Image>().color;
            col.a = 1;
            GetComponent<Image>().color = col;
        }
    }
}
