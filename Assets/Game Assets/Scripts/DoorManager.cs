using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DoorManager : MonoBehaviour
{

    //public GameObject key;
    Image Eq;
    public string TypeOfKey;
     Animation anim;
    public string anime;
    bool isopen = false;
    public DoorType Type;
    public string Floor;
    public AudioClip DoorOpen;
    GameObject hint;
    bool iskey;
	void Start ()
    {

        hint = GameObject.FindGameObjectWithTag("Hint");
        Eq = GameObject.FindGameObjectWithTag("Equipment").GetComponent<Image>();
        anim = GetComponent<Animation>();
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (Type == DoorType.Normal)
            {
               //Debug.Log("przed eq");
                foreach (Transform item in Eq.transform)
                {
                    if (item.tag == "Key")
                    {
                        //Debug.Log("klucz sie zgadza");
                        if (item.GetComponent<EquipmentDragging>().info == TypeOfKey)
                        {
                            iskey = true;
                            if (isopen == false)
                            {
                                GetComponent<AudioSource>().PlayOneShot(DoorOpen);
                                anim.Play(anime);
                                StartCoroutine("Wait");
                                if(gameObject.tag == "227")
                                {
                                    hint.SendMessage("ShowHint", "I made it! Now, I should try to turn on the lights, generator is probably in basement.");
                                }
                            }
                        }
                    }
                }

                if (iskey == false)
                {
                    hint.SendMessage("ShowHint", "Looks like this door are shut. I need key if I want to open it.");
                    if (gameObject.tag == "227")
                    {
                        hint.SendMessage("ShowHint", "I need to look around, maybe there is something helpful in the professor's desk.");
                    }
                }
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(DoorOpen);
                DontDestroyOnLoad(col.gameObject);
                DontDestroyOnLoad(GameObject.Find("EquipmentWindow"));
                DontDestroyOnLoad(GameObject.Find("HeroUI"));
                DontDestroyOnLoad(GameObject.Find("Dead"));
                DontDestroyOnLoad(GameObject.Find("MenuGame"));
                if (GameObject.Find("Enemy") != null)
                {
                    Destroy(GameObject.Find("Enemy"));
                }
                if (GameObject.Find("Fog") != null)
                {
                    Destroy(GameObject.Find("Fog"));
                }
                SceneManager.LoadScene(Floor);
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.10f);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        // Debug.Log("otworz drzwi");
        isopen = true;
    }
}
