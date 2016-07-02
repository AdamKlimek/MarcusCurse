using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

public class ActionBar : MonoBehaviour
{

    public Image Slot;
    private Image ItemBar;
    private Sprite Item;
    private GameObject hero;
    private float AmountOfHeal;
    public Sprite tex;
    // Use this for initialization
    void Start ()
    {
        ItemBar = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Slot.transform.childCount == 1)
        {
            Item = Slot.transform.GetChild(0).GetComponent<Image>().sprite;
            ItemBar.sprite = Item;
            if (Slot.GetComponent<ItemArea>().Type == EquipmentType.Food)
            {
                if (Input.GetKeyUp(KeyCode.R))
                {
                    AmountOfHeal = Slot.transform.GetChild(0).GetComponent<EquipmentDragging>().AmountOfHeal;
                    GameObject.FindGameObjectWithTag("Player").SendMessage("Heal", AmountOfHeal);
                    Destroy(Slot.transform.GetChild(0).gameObject);
                }
            }
        }
        else
        {
            ItemBar.sprite = tex;
        }
	
	}
}
