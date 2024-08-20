using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnObstacle
{
    [Header("Basic Info")]
    public GameObject Obstacle;
    public float MoveSpeed;

    [Header("Spawning Info")]
    public float SpawnTime;
    public Transform SpawnPoint;

    [Header("sin waves settings")]
    public float amplitude = 0f;
    public float frequency = 0f;
    [SerializeField] public bool hasSpawned { get; set; }

}
public class GameSceneManager : MonoBehaviour
{
    #region Singleton

    private static GameSceneManager instance;

    public static GameSceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameSceneManager>();
            }
            return instance;
        }
    }

    #endregion
    public enum GameState
    {
        WaitForStart,
        GameStart,
        GameOver
    }
    [SerializeField] private GameObject Player;
    [SerializeField] private bool StartTheGame = false;
    [SerializeField] private SpawnObstacle[] SpawnObstacles;
    private float Timer = 0;
    private GameState state;

    public EventHandler startGameHandler;

    private void Awake() => instance = this;
    void Start()
    {
        state = GameState.WaitForStart; // Initial state
    }
    void Update()
    {
        GameStateDetect();
        SpawningObstacle();
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
                    startGameHandler?.Invoke(this, EventArgs.Empty);
                }
                break;

            case GameState.GameStart:
                if (!UIManager.paused)
                {
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }

                Timer = Time.time;
                if (Player.GetComponent<PlayerHealth>().IfPlayerDead())
                {
                    state = GameState.GameOver;
                }
                break;

            case GameState.GameOver:

                Timer = 0;
                break;
        }
    }
    private void SpawningObstacle()
    {
        foreach (SpawnObstacle _spawnObstacles in SpawnObstacles)
        {
            if (Timer >= _spawnObstacles.SpawnTime && !_spawnObstacles.hasSpawned)
            {
                GameObject obstacle = Instantiate(_spawnObstacles.Obstacle, _spawnObstacles.SpawnPoint);
                Destroy(obstacle, 8);
                GetObstacleInfo(obstacle, _spawnObstacles);

            }
        }
    }
    private void GetObstacleInfo(GameObject obs, SpawnObstacle spawnedObs)
    {
        if (obs.gameObject.tag == "RangeDamage")
        {
            obs.GetComponent<AwareScaleChange>().InitRangeDamage();
        }
        else
        {
            obs.GetComponent<MovingEnemies>().MoveSpeed = spawnedObs.MoveSpeed;
            obs.GetComponent<MovingEnemies>().amplitude = spawnedObs.amplitude;
            obs.GetComponent<MovingEnemies>().frequency = spawnedObs.frequency;
            obs.GetComponent<MovingEnemies>().SetPlayerPosition(Player.transform.position);
        }
        spawnedObs.hasSpawned = true;
    }
}



















