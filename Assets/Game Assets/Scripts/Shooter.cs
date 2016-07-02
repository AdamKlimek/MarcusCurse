using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public Rigidbody bullet;
    public int Force = 15;
    float time = 0.0f;
    public AudioClip fire;
   // GameObject parent;
    // Use this for initialization
    void Start ()
    {
      //parent = GameObject.Find("Enemy");
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void EnemyShoot()
    {
        time += Time.deltaTime;
        if (time >= 1.0f)
        {
           GameObject.FindGameObjectWithTag("Enemy").GetComponent<AudioSource>().PlayOneShot(fire);
            Rigidbody clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.forward * Force;
            // clone.AddForce(Force * transform.forward);
            time = 0.0f;
            Destroy(clone.gameObject, 2);
        }
    }
}
