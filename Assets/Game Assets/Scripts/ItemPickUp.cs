using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour {

    public Canvas EqWindow;
    public Image Backpack;
    private GameObject Item;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ToInventory(GameObject obj)
    {
        Item = new GameObject();
        Image img = Item.AddComponent<Image>();
        img.sprite = obj.GetComponent<Image>().sprite;

        Item.GetComponent<RectTransform>().SetParent(Backpack.transform);
        Item.AddComponent<CanvasGroup>();
        Item.AddComponent<EquipmentDragging>();
        Item.GetComponent<EquipmentDragging>().Type = obj.GetComponent<EquipmentDragging>().Type;
        Item.GetComponent<EquipmentDragging>().message = EqWindow.transform.FindChild("Message").GetComponent<Text>();
        Item.GetComponent<EquipmentDragging>().info = obj.GetComponent<EquipmentDragging>().info;
        Item.GetComponent<EquipmentDragging>().AmountOfHeal = obj.GetComponent<EquipmentDragging>().AmountOfHeal;
        Item.tag = obj.tag;
        Item.name = obj.name;
        Item.SetActive(true);
    }
}
