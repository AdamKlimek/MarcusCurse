using UnityEngine;
using System.Collections;

public class DestroyGhost : MonoBehaviour {

    GameObject Enemy;
    public AudioClip death;
    // Use this for initialization
    void Start ()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");

    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<ParticleSystem>().Stop();
    }

    void GhostIsDead()
    {
        gameObject.transform.position = Enemy.transform.position;
            gameObject.GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().PlayOneShot(death);
        Destroy(Enemy);
        StartCoroutine("Wait");
          
    }
}
