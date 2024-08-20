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
        GameOver,
        GamePause,
        Winning }
    [SerializeField] private GameObject Player;
    [SerializeField] private bool StartTheGame = false;
    [SerializeField] private SpawnObstacle[] SpawnObstacles;
    [SerializeField] private float SpawnDelayDelta = 0f;
    
    public float StartTime = 0f;
    private float EndTime;
    public float Timer = 0;
    public GameState state;
    
    int SpawnCount = 0;
    private bool ReadyToFinish = false;
    
    private GamePlayUI _gamePlayUI;
    [SerializeField]
    private GamePlayTimer _gamePlayTimer;
    private void Awake() => instance = this;
    void Start()
    {
        state = GameState.WaitForStart; // Initial state
        _gamePlayUI = transform.Find("GamePlayUI").GetComponent<GamePlayUI>();
    }
    void Update()
    {
        GameStateDetect();
        SpawningObstacle();
        UpdateTimer();
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
                    StartTime = Time.time;
                    EndTime = StartTime + AudioManager.Instance.audioSource.clip.length;
                    AudioManager.Instance.TogglePlay(true);
                }
                break;

            case GameState.GameStart:
                Time.timeScale = 1;
                
                if (Player.GetComponent<PlayerHealth>().IfPlayerDead()) {
                    state = GameState.GameOver;
                    Time.timeScale = 0;
                    AudioManager.Instance.TogglePlay(false);
                    _gamePlayUI.ShowGameOverView();
                }
                if (Input.GetKeyDown(KeyCode.Escape)) {
                    state = GameState.GamePause;
                    AudioManager.Instance.TogglePlay(false);
                    _gamePlayUI.ShowPauseView();
                }
                
                if (SpawnCount != SpawnObstacles.Length) {
                    Timer = Time.time;
                }else {
                    ReadyToFinish = true;
                }

                if (ReadyToFinish && Time.time - Timer > 9f)
                {
                    state = GameState.Winning;
                    Time.timeScale = 0;
                    _gamePlayUI.ShowWinView(Player.GetComponent<PlayerHealth>().Current_PlayerHealth);
                }
                break;
            case GameState.GamePause:
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    AudioManager.Instance.TogglePlay(true);
                    state = GameState.GameStart;
                    _gamePlayUI.HidePauseView();
                }
                break;
            
        }
    }
    private void SpawningObstacle()
    {
        foreach (SpawnObstacle _spawnObstacles in SpawnObstacles)
        {
            if ((Timer - StartTime) >= _spawnObstacles.SpawnTime+SpawnDelayDelta  && !_spawnObstacles.hasSpawned)
            {
                GameObject obstacle = Instantiate(_spawnObstacles.Obstacle, _spawnObstacles.SpawnPoint);
                Destroy(obstacle, 8);
                GetObstacleInfo(obstacle, _spawnObstacles);
                SpawnCount++;
            }
        }
    }

    private void UpdateTimer()
    {
        _gamePlayTimer.SetSliderValue((Timer - StartTime)/EndTime);
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



















