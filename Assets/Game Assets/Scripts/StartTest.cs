using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class StartTest : MonoBehaviour
{
    public GameObject safe;
    private GameObject spawn;
    public static bool TestDone = false;
    bool isWindow = false;
    bool InProgress = false;
    bool TurnONOFF = false;
    int index;
    public GameObject key;
    public Canvas RiddleWindow;
    public GameObject riddles;
    GameObject hint;
    Canvas Window;
    public string letter;
    //public AudioClip screen;
    // Use this for initialization
    void Start()
    {
        hint = GameObject.FindGameObjectWithTag("Hint");
        spawn = safe.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && TurnONOFF == true)
        {
            if (Window != null)
            {
                Window.enabled = !Window.enabled;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        hint.SendMessage("ShowHint", "I should use this computer and solve the mystery.");
       TurnONOFF = true;
        if (isWindow == false)
        {
            Window = Instantiate(RiddleWindow, col.transform.position, col.transform.rotation) as Canvas;
            for (int i = 0; i < Window.GetComponent<RidlleSystem>().riddle.Count; i++)
            {
                Window.GetComponent<RidlleSystem>().riddle[i] = riddles.transform.GetChild(i).GetComponent<Riddle>();
            }
            isWindow = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            if (Window != null)
            {
                if (Window.enabled == true)
                {
                    col.GetComponentInChildren<Hero>().enabled = false;
                    col.GetComponent<FirstPersonController>().enabled = false;
                    Time.timeScale = 0;
                    if (InProgress == false)
                    {
                        index = Random.Range(0, Window.GetComponent<RidlleSystem>().riddle.Count);
                        Window.SendMessage("LoadRiddle", index);
                        InProgress = true;
                    }
                    Window.SendMessage("RiddleLogic", index);
                    // riddle.RemoveAt(index);
                    if (TestDone == true)
                    {
                        hint.SendMessage("ShowHint", "Yes! I solved the mystery! The safe is now open and I got a new key and another part of code to the door!  I'm closer to find a way to escape from this building! ");
                        safe.GetComponentInChildren<Animation>().Play("safeopen");
                        GameObject.FindGameObjectWithTag("Player").SendMessage("AddLetter", letter);
                        Instantiate(key, spawn.transform.position, spawn.transform.rotation);
                        Window.enabled = false;
                        Destroy(Window.gameObject);
                        TestDone = false;
                        InProgress = false;
                        isWindow = false;
                        gameObject.GetComponent<BoxCollider>().enabled = false;
                    }
                }
                else
                {
                    col.GetComponentInChildren<Hero>().enabled = true;
                    col.GetComponent<FirstPersonController>().enabled = true;
                    Time.timeScale = 1;
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        TurnONOFF = false;
    }
}