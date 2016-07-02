using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlashlightControl : MonoBehaviour
{
    Light Flashlight;
    public Image OffHand;
    public AudioClip TurnOn;
    public Canvas Equipment;

    // Use this for initialization
    void Start ()
    {
        Flashlight = transform.GetChild(0).GetComponentInChildren<Light>();
        Flashlight.enabled = false;
        Equipment = GameObject.Find("EquipmentWindow").GetComponent<Canvas>();

    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyUp(KeyCode.F) && OffHand.transform.childCount == 1)
        {
            if (Flashlight.enabled == true)
            {
                GetComponent<AudioSource>().PlayOneShot(TurnOn);
                Flashlight.enabled = false;
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(TurnOn);
                Flashlight.enabled = true;
            }
        }

        if(Input.GetKeyUp(KeyCode.Escape) && Equipment.enabled == false)
        {
            Destroy(GameObject.Find("EquipmentWindow"));
            Destroy(GameObject.Find("HeroUI"));
            Destroy(GameObject.Find("Dead"));
            Destroy(GameObject.Find("Player"));
            Destroy(GameObject.Find("diff"));
            SceneManager.LoadScene(0);
        }
	}
}
