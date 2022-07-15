using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuEventHandler : MonoBehaviour
{
    [SerializeField] private TrapGenerator _trapGenerator;
    private void OnEnable()
    {
        _trapGenerator.OnGameFinish += OnGameFinished;
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame(GameObject Ui)
    {
        Ui.SetActive(false);
        Time.timeScale = 1f;
    }
    
    private void OnGameFinished()
    {
        Debug.Log("Finished");
    }
}