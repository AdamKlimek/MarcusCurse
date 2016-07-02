using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour
{
    Animation anim;
    GameObject hint;
    bool use = false;
    public AudioClip ruch;
	// Use this for initialization
	void Start ()
    {
            anim = GetComponentInChildren<Animation>();
            hint = GameObject.FindGameObjectWithTag("Hint");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player" && Input.GetKey(KeyCode.E) == true )
        {
            GetComponent<AudioSource>().PlayOneShot(ruch);
                if(use == false)
                {
                    anim.Play("Lever down");
                    hint.SendMessage("ShowHint", "Oh no...it's not working.Good that I have flashlight");
                    use = true;
                }
                else
                {
                    anim.Play("lever up");
                    use = false;
            }
        }
    }
}
