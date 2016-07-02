using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RidlleSystem : MonoBehaviour
{
    Image A, B, C, D, Question;
    public List<Riddle> riddle = new List<Riddle>();
    GameObject hero;
     public AudioClip good, wrong , hurt;
    int i;
    // Use this for initialization
    void Start ()
    {
        A = GameObject.Find("A").GetComponent<Image>();
        B = GameObject.Find("B").GetComponent<Image>();
        C = GameObject.Find("C").GetComponent<Image>();
        D = GameObject.Find("D").GetComponent<Image>();
        Question = GameObject.Find("Question").GetComponent<Image>();
        hero = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RiddleLogic(int index)
    {
        if (Input.GetKeyDown(KeyCode.A) ) 
        {
            i = 0;
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            i = 1;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            i = 2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            i = 3;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.D))
        {
            if (riddle[index].Answer[i].Type == AnswerType.correct)
            {   
                GetComponent<AudioSource>().PlayOneShot(good);
                StartCoroutine("Wait");
                if (GetComponent<AudioSource>().isPlaying == false)
                {
                    StartTest.TestDone = true;
                }

            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(wrong);
                StartCoroutine("Wait2");
                hero.GetComponent<HealthControl>().HealthPoints -= 20;
                if (hero.GetComponent<HealthControl>().HealthPoints <= 0)
                {
                    hero.GetComponent<HealthControl>().HealthPoints = 0;
                    StartCoroutine("Wait3");
                }
            }
        }
    }

    void LoadRiddle(int index)
    {
        A.sprite = riddle[index].Answer[0].picture;
        B.sprite = riddle[index].Answer[1].picture;
        C.sprite = riddle[index].Answer[2].picture;
        D.sprite = riddle[index].Answer[3].picture;
        Question.sprite = riddle[index].Question;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        StartTest.TestDone = true;
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<AudioSource>().PlayOneShot(hurt);
    }

    IEnumerator Wait3()
    {
        yield return new WaitForSeconds(0.3f);
        hero.SendMessage("Dead");
    }
}
