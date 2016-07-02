using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentDragging : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler , IPointerEnterHandler, IPointerExitHandler , IPointerClickHandler
{
    private Transform ObjectToMove;
    private Transform ParentObject;
    public Text message;
    public string info;
    public EquipmentType Type;
    public float AmountOfHeal;
    // Use this for initialization
    void Start ()
    {
        ObjectToMove = GetComponent<Transform>();
        ParentObject = ObjectToMove.parent;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        //Na czas przeciągania obiektu zmieniam rodzica
        //aby nasz element nie zmieniał pozycji w ekwipunku (rodzicem będzie płutno).
        ObjectToMove.SetParent(ParentObject.parent);

        //Włączamy wykrywanie kursora myszy popbrzez wyłaczenie blokady promienia.
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    /**
	 * Metoda wywoływana w czasie przeciągania elementu.
	 */
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        //Aktualizujemy pozycję elementu o aktualną pozycję kursora.
        ObjectToMove.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // Debug.Log("OnEndDrag");
        //Ponownie przypisujemy rodzica ekwipunku do elementu
        //spowoduje to jego ustawienie/posortowanie w ekwipunku.
        ObjectToMove.SetParent(ParentObject);

        //Wyłączamy wykrywanie kursora myszy popbrzez właczenie blokady promienia.
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public Transform GetParentObject()
    {
        return ParentObject;
    }
    public void SetParentObject(Transform trans)
    {
        ParentObject = trans;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
            message.enabled = true;
            message.text = info;
            message.transform.position = eventData.position;
            message.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        message.enabled = false;
        message.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.transform.parent.GetComponent<ItemArea>().Type == EquipmentType.None)
        {
            if (Input.GetButtonUp("PPM"))
            {
                if (Type == EquipmentType.Food)
                {
                    GameObject.FindGameObjectWithTag("Player").SendMessage("Heal", AmountOfHeal);
                    Destroy(gameObject);
                }
            }
        }
    }
}
