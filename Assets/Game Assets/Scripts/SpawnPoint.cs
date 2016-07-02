using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    int level = 1;
    bool candle;
    public GameObject target;
    public GameObject Fog;
    GameObject SpawnPointEnemy;
    GameObject hint;
    public GameObject  eq, heroUI;
    //public AudioClip fight;
    // Use this for initialization
    void Start ()
    {
        candle = false;
        hint = GameObject.FindGameObjectWithTag("Hint");
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    void OnLevelWasLoaded(int thisLevel)
    {
        SpawnPointEnemy = GameObject.Find("Spawn Point Enemy");
        if(thisLevel == 6 && level == 1 )
        {
            Debug.Log("wchodze na 2 pietro");
            transform.position = GameObject.FindWithTag("Spawn").transform.position;
            heroUI.GetComponent<Canvas>().enabled = true;
            hint.SendMessage("ShowHint", "What happened ?! Where am I ? I think I fell asleep. I need to get out of here. Thank God I have my flashlight in backpack... it's dark everywhere!");
            level = thisLevel;
        }
        if(thisLevel == 2 && level == 3)
        {
            Debug.Log("wchodze do piwnicy");
            transform.position = GameObject.FindWithTag("Entry[-2,-1]").transform.GetChild(0).position ;
            Instantiate(target, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            Instantiate(Fog, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            level = thisLevel;
            if(candle == false)
            {
                hint.SendMessage("ShowHint", "There's something wrong here. Somebody is here. I think I should light up candles in front of me. Light will be helpful.");
                // GetComponent<AudioSource>().PlayOneShot(fight);
                Light[] List = FindObjectsOfType<Light>();
                foreach (Light item in List)
                {
                    if (item.name == "CandleLight")
                    {
                        item.enabled = false;
                    }
                }

                GameObject[] candlelist = FindObjectsOfType<GameObject>();
                foreach (GameObject item in candlelist)
                {
                    if (item.tag == "Candle")
                    {
                        Enemy.ptr = item.GetComponentInChildren<ParticleSystem>().emission;
                        Enemy.ptr.enabled = false;
                    }
                }

                candle = true;
            }
        }
        else if(thisLevel == 3 && level == 2)
        {
            Debug.Log("ide do wyjscia");
            transform.position = GameObject.FindWithTag("Entry[-2,-1]").transform.GetChild(0).position;
            level = thisLevel;
        }
        else if (thisLevel == 3 && level == 4)
        {
            Debug.Log("ide do wyjscia");
            transform.position = GameObject.FindWithTag("Entry[-1,0]").transform.GetChild(0).position;
            level = thisLevel;
        }
        else if (thisLevel == 4 && level == 3)
        {
            Debug.Log("wchodze na parter");
            transform.position = GameObject.FindWithTag("Entry[-1,0]").transform.GetChild(0).position;
            Instantiate(target, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            Instantiate(Fog, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            level = thisLevel;
        }
        else if (thisLevel == 4 && level == 5)
        {
            Debug.Log("wchodze na parter");
            transform.position = GameObject.FindWithTag("Entry[0,1]").transform.GetChild(0).position;
            Instantiate(target, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            Instantiate(Fog, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            level = thisLevel;
        }
        else if (thisLevel == 5 &&  level == 4)
        {
            Debug.Log("wchodze na pietro 1");
            transform.position = GameObject.FindWithTag("Entry[0,1]").transform.GetChild(0).position;
            Instantiate(target, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            Instantiate(Fog, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            level = thisLevel;
        }
        else if (thisLevel == 6 && level == 5)
        {
            Debug.Log("wchodze na pietro 2");
            transform.position = GameObject.FindWithTag("Entry[1,2]").transform.GetChild(0).position;
            Instantiate(target, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            Instantiate(Fog, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            level = thisLevel;
        }
        else if (thisLevel == 5 && level == 6)
        {
            Debug.Log("wchodze na pietro 1");
            transform.position = GameObject.FindWithTag("Entry[1,2]").transform.GetChild(0).position;
            Instantiate(target, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            Instantiate(Fog, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            level = thisLevel;
        }
        else if (thisLevel == 6 && level == 7)
        {
            Debug.Log("wchodze na pietro 2");
            transform.position = GameObject.FindWithTag("Entry[2,3]").transform.GetChild(0).position;
            Instantiate(target, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            Instantiate(Fog, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            level = thisLevel;
        }
        else if (thisLevel == 7 && level == 6)
        {
            Debug.Log("wchodze na pietro 3");
            transform.position = GameObject.FindWithTag("Entry[2,3]").transform.GetChild(0).position;
            Instantiate(target, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            Instantiate(Fog, SpawnPointEnemy.transform.position, SpawnPointEnemy.transform.rotation);
            level = thisLevel;
        }
    }
}
