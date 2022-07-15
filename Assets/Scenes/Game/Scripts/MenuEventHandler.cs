using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEventHandler : MonoBehaviour
{
    [SerializeField] private TrapGenerator _trapGenerator;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _losePanel;
    private void OnEnable()
    {
        _trapGenerator.OnGameFinish += OnGameFinished;
        _player.OnLoseGame += OnGameLose;
    }

    private void Start()
    {
        SetGameTime(0);
    }

    public void StartGame(GameObject Ui)
    {
        Ui.SetActive(false);
        SetGameTime(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    private void OnGameFinished()
    {
        _finishPanel.SetActive(true);
        SetGameTime(0);
    }

    public void SetGameTime(int time)
    {
        Time.timeScale = time;
    }
    private void OnGameLose()
    {
        _losePanel.SetActive(true);
       SetGameTime(0);
    }
}