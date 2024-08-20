using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    
    #endregion
    
    public string CurrentSceneName { get => SceneManager.GetActiveScene().name; }
    private void Awake() {
        _instance = this;
        DontDestroyOnLoad(this);
    }
    
    public void ChangeScene(string sceneName) {
        if (sceneName == CurrentSceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        SceneManager.LoadScene(sceneName);
    }

    public void Update()
    {
        
    }
}