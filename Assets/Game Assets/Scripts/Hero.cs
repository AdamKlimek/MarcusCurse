using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hero : MonoBehaviour {

    public float force = 0.0f;
    static  public float ActuallyForce = 0.0f;
    public Image ForceBar;
    public Image ForceBarBackground;
    float StepToLoadForce = 50.0f;
    float MaxForce = 2000;
    public Rigidbody bullet;
    public Image Slot;
    public AudioClip fire;
    // Use this for initialization
    void Start ()
    {
        ForceBar.enabled = false;
        ForceBarBackground.enabled = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Slot.transform.childCount == 1)
        {
            CheckForce();
        }
	}

    void CheckForce()
    {
        if(Input.GetButton("LPM") && force/MaxForce < 1 )
        {
            ForceBar.enabled = true;
            ForceBarBackground.enabled = true;
            force += StepToLoadForce;
            if (force/ MaxForce >= 1)
            {
                force = MaxForce;
            }
            ForceBar.rectTransform.localScale = new Vector3(ForceBar.rectTransform.localScale.x , force/ MaxForce, ForceBar.rectTransform.localScale.z);
        }
         else if (!Input.GetButton("LPM") && force/ MaxForce > 0)
        {

           
            if (Input.GetButtonUp("LPM"))
            {
                ActuallyForce = force;
                Shoot();

            }
            force -= StepToLoadForce;
            if(force/ MaxForce <= 0)
            {
                force = 0;
                ForceBar.enabled = false;
                ForceBarBackground.enabled = false;
            }
            ForceBar.rectTransform.localScale = new Vector3(ForceBar.rectTransform.localScale.x, force/ MaxForce, ForceBar.rectTransform.localScale.z);
        }
    }

    void Shoot()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(fire);
        Rigidbody clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
        clone.AddForce(force * Camera.main.transform.forward);
        Destroy(clone.gameObject, 0.5f);
    }
}
