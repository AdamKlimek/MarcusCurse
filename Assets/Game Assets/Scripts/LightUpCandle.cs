using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightUpCandle : MonoBehaviour {

    Renderer CandleFlame;
    static public int CandleLightUp;
    static public List<GameObject> CandleIsLit;
    static public bool IsLit;
    public AudioClip fire;
    // Use this for initialization
    void Start ()
    {
        IsLit = false;
        CandleIsLit = new List<GameObject>();
        CandleLightUp = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Candle")
        {
            Enemy.ptr = col.gameObject.GetComponentInChildren<ParticleSystem>().emission;
            if (Input.GetButtonDown("Use") && Enemy.ptr.enabled == false)
            {
                GetComponent<AudioSource>().PlayOneShot(fire);
                Enemy.ptr.enabled = true;
                col.gameObject.GetComponentInChildren<Light>().enabled = true;
                CandleIsLit.Add(col.gameObject);
                if (CandleLightUp < 4)
                {
                    CandleLightUp++;
                }
            }
        }
    }
}
