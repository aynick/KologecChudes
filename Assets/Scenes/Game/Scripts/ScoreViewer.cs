using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    private TMP_Text _text;
    [SerializeField] private ScoreRecorder _scoreRecorder;

    private void OnEnable()
    {
        _scoreRecorder.OnScoreUpdate += UpdateScore;
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = PlayerPrefs.GetInt("Score").ToString();
    }

    private void UpdateScore(int score)
    {
        _text.text = score.ToString();
    }
    
}
