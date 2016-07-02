using UnityEngine;
using System.Collections;

public class AnimationGhost : MonoBehaviour {

    Animation anim;

    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void StopAnimation(string name)
    {
        anim.Stop(name);
    }

    void PlayAnimation(string name)
    {
            anim.Play(name);
    }
}
