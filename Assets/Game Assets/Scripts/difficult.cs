using UnityEngine;
using System.Collections;

public class difficult : MonoBehaviour {

    public float Di;
	// Use this for initialization
	void Start ()
    {
        Di = 180.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void  SetDifficult(float diff)
    {
        Di = diff;
    }

}
