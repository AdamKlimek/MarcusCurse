using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    private float RotationSpeed = 100.0f;
    public EquipmentType Type;
    public string message;
    private GameObject obj;
    public float AmountOfHeal;
    public string ItemsName;
    public Sprite texture;
    public AudioClip take;
    // Use this for initialization
    void Start ()
    {
        obj = new GameObject();
        obj.AddComponent<EquipmentDragging>();
        obj.GetComponent<EquipmentDragging>().info = message;
        obj.GetComponent<EquipmentDragging>().Type = Type;
        obj.GetComponent<EquipmentDragging>().AmountOfHeal = AmountOfHeal;
        obj.tag = gameObject.tag;
        obj.name = ItemsName;
        obj.AddComponent<Image>().sprite = texture;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, RotationSpeed * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().PlayOneShot(take);
            col.gameObject.SendMessage("ToInventory" , obj);
            Destroy(gameObject);
        }
    }
}
