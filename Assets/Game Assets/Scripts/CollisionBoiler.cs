using UnityEngine;
using System.Collections;

public class CollisionBoiler : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    void OnCollisionEnter(Collision Coal)
    {
        if (Coal.gameObject.CompareTag("Coal"))
        {
            TemperatureControl.isCollision = true;
        }
    }
}
