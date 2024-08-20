using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    private PauseView _pauseView;
    private WinView _winView;
    private GameOverView _gameOverView;

    private void Awake()
    {
        _pauseView = transform.Find("Pause").GetComponent<PauseView>();
        _winView = transform.Find("Win").GetComponent<WinView>();
        _gameOverView = transform.Find("GameOver").GetComponent<GameOverView>();
    }
    
    public void ShowPauseView() => _pauseView.Show();
    public void HidePauseView() => _pauseView.Hide();

    public void ShowWinView(float Playerhealth)
    {
        _winView.SetWinData(Playerhealth);
        _winView.Show();
    } 
        
    public void ShowGameOverView() => _gameOverView.Show();
}
