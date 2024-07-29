using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Manuals : ColorChangingText, IPointerClickHandler
{
    [SerializeField] GameObject manualsUI;
    public void OnPointerClick(PointerEventData eventData)
    {
        manualsUI.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
