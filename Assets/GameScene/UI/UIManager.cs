using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    #region Singleton

    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    #endregion
    [SerializeField] private Canvas PauseCanvas;
    [SerializeField] private Canvas GameOverCanvas;
    [SerializeField] private Button Continue_Btm;
    [SerializeField] private Button[] Restart_Btm;
    [SerializeField] private Button[] Home_Btm;

    [SerializeField] private PlayerHealth _playerHealth;

    public bool paused = false;
    void Start()
    {

        paused = false;
        PauseCanvas.gameObject.SetActive(false);
        GameOverCanvas.gameObject.SetActive(false);

        Continue_Btm.onClick.AddListener(() => { Continue(); });
        foreach (Button button in Restart_Btm)
        {
            button.onClick.AddListener(() => { Restart(); });
        }
        foreach (Button button in Home_Btm)
        {
            button.onClick.AddListener(() => { Home(); });
        }

    }

    private void Home()
    {

    }

    private void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void Continue()
    {
        if (paused)
        {
            paused = false;
            PauseCanvas.gameObject.SetActive(paused);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            PauseCanvas.gameObject.SetActive(paused);
        }

    }
    public void ShowGameOverCanvas()
    {
        GameOverCanvas.gameObject.SetActive(true);
    }

}
