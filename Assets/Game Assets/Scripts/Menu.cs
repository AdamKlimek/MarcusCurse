using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    static public string page =  "main";
    public GameObject NewGame, Instructions, Exit, ControlInstructions , Return , Options , Difficult , Easy , Medium , Hard, Credits , Author;
    // Use this for initialization
    void Start ()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (page == "main")
        {
            Difficult.SetActive(false);
            NewGame.SetActive(true);
            Instructions.SetActive(false);
            Exit.SetActive(true);
            Options.SetActive(true);
            ControlInstructions.SetActive(false);
            Return.SetActive(false);
            Easy.SetActive(false);
            Medium.SetActive(false);
            Hard.SetActive(false);
            Credits.SetActive(false);
            Author.SetActive(false);
        }
        else if(page == "Instructions")
        {
            NewGame.SetActive(false);
            Instructions.SetActive(false);
            Exit.SetActive(false);
            ControlInstructions.SetActive(true);
            Return.SetActive(true);
            Options.SetActive(false);
            Difficult.SetActive(false);
            Easy.SetActive(false);
            Medium.SetActive(false);
            Hard.SetActive(false);
            Credits.SetActive(false);
            Author.SetActive(false);
        }
        else if(page == "options")
        {
            Difficult.SetActive(true);
            Instructions.SetActive(true);
            NewGame.SetActive(false);
            Exit.SetActive(false);
            Return.SetActive(true);
            ControlInstructions.SetActive(false);
            Options.SetActive(false);
            Easy.SetActive(false);
            Medium.SetActive(false);
            Hard.SetActive(false);
            Credits.SetActive(true);
            Author.SetActive(false);
        }
        else if (page == "difficult")
        {
            Instructions.SetActive(false);
            NewGame.SetActive(false);
            Exit.SetActive(false);
            Return.SetActive(true);
            ControlInstructions.SetActive(false);
            Options.SetActive(false);
            Difficult.SetActive(false);
            Easy.SetActive(true);
            Medium.SetActive(true);
            Hard.SetActive(true);
            Credits.SetActive(false);
            Author.SetActive(false);
        }
        else if (page == "credits")
        {
            Instructions.SetActive(false);
            NewGame.SetActive(false);
            Exit.SetActive(false);
            Return.SetActive(true);
            ControlInstructions.SetActive(false);
            Options.SetActive(false);
            Difficult.SetActive(false);
            Easy.SetActive(false);
            Medium.SetActive(false);
            Hard.SetActive(false);
            Credits.SetActive(false);
            Author.SetActive(true);
        }
    }
}
