using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    bool uiOn = false;

    public void DisplayClearUI() {
        DisplayScore();
        gameObject.SetActive(true);
    }

    private void DisplayScore()
    {
        int score = FindAnyObjectByType<ScoreBoard>().Score;
        transform.Find("Score").gameObject.GetComponent<TMP_Text>().text = $"SCORE: {score}";
    }
}
