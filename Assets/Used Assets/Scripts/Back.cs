using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Back : ColorChangingText, IPointerClickHandler
{
    [SerializeField] GameObject homeUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        homeUI.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);

    }
}
