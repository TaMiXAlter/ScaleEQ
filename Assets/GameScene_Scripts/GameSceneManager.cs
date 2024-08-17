using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnObstacle
{
    public int SpawnTime;
    public GameObject Obstacle;
    public Transform SpawnPoint;
    [SerializeField] public bool hasSpawned { get; set; }
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
        foreach (SpawnObstacle _spawnObstacles in SpawnObstacles)
        {
            if (Timer >= _spawnObstacles.SpawnTime && !_spawnObstacles.hasSpawned)
            {
                Instantiate(_spawnObstacles.Obstacle, _spawnObstacles.SpawnPoint);
                _spawnObstacles.hasSpawned = true;
            }
        }
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
