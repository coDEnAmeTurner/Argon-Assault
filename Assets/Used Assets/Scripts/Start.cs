using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Start : ColorChangingText, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        LoadStage1();
    }

    private static void LoadStage1()
    {
        SceneManager.LoadScene(1);
    }

    
}
