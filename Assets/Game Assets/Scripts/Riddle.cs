using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Riddle : MonoBehaviour
{
    [System.Serializable]
    public struct AnswerObject
    {
        public Sprite picture;
         public AnswerType Type;
    }
    public AnswerObject[] Answer = new AnswerObject[4];
    public Sprite Question;
    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

}
