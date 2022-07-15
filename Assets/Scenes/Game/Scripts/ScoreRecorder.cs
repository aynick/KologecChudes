using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreRecorder : MonoBehaviour
{
    public event Action<int> OnScoreUpdate;
    private int score;
    private void Start()
    {
        StartCoroutine(ScoreRecord());
    }

    IEnumerator ScoreRecord()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            OnScoreUpdate?.Invoke(score);
            if (PlayerPrefs.GetInt("Score") < score) 
                PlayerPrefs.SetInt("Score",score);
            
        } 
    }
}
