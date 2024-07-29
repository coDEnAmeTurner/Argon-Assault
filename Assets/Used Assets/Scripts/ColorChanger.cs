using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ColorChangingText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerExit(PointerEventData eventData)
    {
        ChangeExitColor();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeHoverColor();

    }

    private void ChangeHoverColor()
    {
        gameObject.GetComponent<TMP_Text>().color = Color.red;
    }
    private void ChangeExitColor()
    {
        gameObject.GetComponent<TMP_Text>().color = Color.yellow;
    }
}
