using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Exit : ColorChangingText, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        QuitApp();
    }

    private void QuitApp()
    {
        Application.Quit();
    }
}

