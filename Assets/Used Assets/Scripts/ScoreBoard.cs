using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;
    PlayableDirector masterTimeline;


    public int Score { get => score; set => score = value; }

    private void Awake()
    {
        ResetScore(null);
        masterTimeline = GameObject.FindGameObjectWithTag("Master Timeline").GetComponent<PlayableDirector>();
        masterTimeline.played += ResetScore;
    }

    public void ResetScore(PlayableDirector director)
    {
        Score = 0;
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "START";
    }

    public void IncreaseScore(int amountToIncrease)
    {
        Score += amountToIncrease;
        scoreText.text = $"SCORE: {Score}";

    }


}
