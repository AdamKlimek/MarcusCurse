using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayOutro : MonoBehaviour {
    public MovieTexture movie;
    AudioSource sound;
    // Use this for initialization
    void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        sound = GetComponent<AudioSource>();
        sound.clip = movie.audioClip;
        movie.Play();
        sound.Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(movie.isPlaying == false)
        {
            SceneManager.LoadScene(0);
        }
	}
}
