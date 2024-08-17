using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnObstacle
{
    public GameObject Obstacle;
    public int SpawnTime;
    public Transform SpawnPoint;
    private bool hasSpawned = false;
}
public class GameSceneManager : MonoBehaviour
{

    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private bool StartTheGame = false;
    private float Timer = 0;
    public enum GameState
    {
        WaitForStart,
        GameStart,
        GameOver
    }
    private GameState state;


    [SerializeField] private SpawnObstacle[] SpawnObstacles;
    void Start()
    {
        state = GameState.WaitForStart;
    }


    void Update()
    {
        Debug.Log(state);
        GameStateDetect();




    }

    private void GameStateDetect()
    {
        switch (state)
        {
            case GameState.WaitForStart:

                Time.timeScale = 0;
                if (StartTheGame)
                {
                    state = GameState.GameStart;
                }
                break;
            case GameState.GameStart:

                Time.timeScale = 1;
                Timer = Time.time;
                if (_playerHealth.IfPlayerDead())
                {
                    state = GameState.GameOver;
                }
                break;

            case GameState.GameOver:

                Timer = 0;
                Debug.Log("GameOver");
                break;
        }
    }
}
