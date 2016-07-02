using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerDead : MonoBehaviour
{
    public GameObject  Menu;
    public AudioClip Death;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void Dead()
    {
        GetComponent<AudioSource>().PlayOneShot(Death);
        Menu.SetActive(true);
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5.0f);
        //Menu.SetActive(false);
        Destroy(gameObject);
        Destroy(GameObject.Find("EquipmentWindow"));
        Destroy(GameObject.Find("HeroUI"));
        Destroy(GameObject.Find("Dead"));
        Destroy(GameObject.Find("diff"));
        SceneManager.LoadScene(0);
    }
}
