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
    
    private void Awake() {
        _instance = this;
        DontDestroyOnLoad(this);
    }
    
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    
    
}