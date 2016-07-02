using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemArea : MonoBehaviour, IDropHandler , IPointerEnterHandler, IPointerExitHandler
{
    public Text message;
    public string info;
    private bool IsEmpty = true;
    public EquipmentType Type = EquipmentType.None;
    /** Obiekt ekwipunku.*/
    public GameObject EqWindow;

    /** Maksymalna ilość elementów w obiekcie. */
    public int Capacity = 1;

    /** Obiekt transform bieżącego elementu.*/
    private Transform TransformParent;

    // Use this for initialization
    void Start ()
    {
        message.enabled = false;
        TransformParent = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (TransformParent.childCount < Capacity)
        {
            IsEmpty = true;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
       // Debug.Log(eventData.pointerDrag.name + " upuszczono w " + gameObject.name);

        EquipmentDragging d = eventData.pointerDrag.GetComponent<EquipmentDragging>();

        // Debug.Log(TransformParent.childCount);
        //Sprawdzamy czy slot jest pusty.
        if (Type == d.Type)
        {
            if (TransformParent.childCount < Capacity)
            {
                d.SetParentObject(TransformParent);
                IsEmpty = false;
            }
            else
            {//Slot nie jest pusty i osiągnięto maksymalną ilość elementów.

                //Pobieram obecny element slotu.
                Transform item = transform.GetChild(0);
                //Obecny element slotu przerzucam do ekwipunku poprzez ustawienie rodzica.
                item.SetParent(EqWindow.transform);
                //Umieszczam nowy element w slocie poprzez ustawienie rodzica.
                d.SetParentObject(TransformParent);
                IsEmpty = false;
            }
        }
        else if(Type == EquipmentType.None)
        {
            d.SetParentObject(TransformParent);
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsEmpty == true)
        {
                    message.enabled = true;
                    message.text = info;
                    message.transform.position = eventData.position;
                    message.GetComponent<CanvasGroup>().blocksRaycasts = false;
                    IsEmpty = false;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        message.enabled = false;
        message.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
