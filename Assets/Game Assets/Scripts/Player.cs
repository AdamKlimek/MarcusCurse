using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public MovieTexture movie;
    AudioSource sound;
    public GameObject player, eq, heroUI , dead;
    // Use this for initialization
    void Start ()
    {
        player.SetActive(false);
        eq.SetActive(false);
        heroUI.SetActive(false);
        dead.SetActive(false);
        GetComponent<RawImage>().texture = movie as MovieTexture;
        sound = GetComponent<AudioSource>();
        sound.clip = movie.audioClip;
        movie.Play();
        sound.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            movie.Stop();
            sound.Stop();
        }

        if (movie.isPlaying == false)
        {
            player.SetActive(true);
            eq.SetActive(true);
            eq.GetComponent<Canvas>().enabled = false;
            heroUI.SetActive(true);
            heroUI.GetComponent<Canvas>().enabled = false;
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(eq);
            DontDestroyOnLoad(heroUI);
            DontDestroyOnLoad(dead);
            SceneManager.LoadScene(6);
        }
	}
}
