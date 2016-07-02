using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberGatcher : MonoBehaviour
{
    public GameObject papper;
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void AddLetter(string letter)
    {
        papper.GetComponent<EquipmentDragging>().info += letter;
    }
}
