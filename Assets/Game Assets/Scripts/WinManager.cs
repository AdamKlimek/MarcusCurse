using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    EquipmentDragging papper;
    GameObject hint;
    public AudioClip correct , win , wrong;
    // Use this for initialization
    void Start()
    {
        papper = GameObject.Find("CodeOnPapper").GetComponent<EquipmentDragging>();
        hint = GameObject.FindGameObjectWithTag("Hint");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            if(papper.info.Length == 19)
            {
                GetComponent<AudioSource>().PlayOneShot(correct);
                StartCoroutine("Wait");
                hint.SendMessage("ShowHint", "Yes ! I Win ! I'am Free!!");
                StartCoroutine("Wait");
            }
            else if(papper.info.Length < 19)
            {
                GetComponent<AudioSource>().PlayOneShot(wrong);
                hint.SendMessage("ShowHint", "I have too short PIN !");
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(GameObject.Find("EquipmentWindow"));
        Destroy(GameObject.Find("HeroUI"));
        Destroy(GameObject.Find("Dead"));
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("diff"));
        SceneManager.LoadScene(8);
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<AudioSource>().PlayOneShot(win);
    }
}
