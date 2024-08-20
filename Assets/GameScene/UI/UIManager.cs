using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas PauseCanvas;
    [SerializeField] private Button Continue_Btm;
    [SerializeField] private Button Restart_Btm;
    [SerializeField] private Button Home_Btm;

    public static UIManager instance;
    public static bool paused = false;
    void Start()
    {
        instance = this;
        paused = false;
        PauseCanvas.gameObject.SetActive(false);

        Continue_Btm.onClick.AddListener(Continue());
        Restart_Btm.onClick.AddListener(Restart());
        Home_Btm.onClick.AddListener(Home());
    }

    private UnityAction Home()
    {
        throw new NotImplementedException();
    }

    private UnityAction Restart()
    {
        throw new NotImplementedException();
    }

    private UnityAction Continue()
    {
        throw new NotImplementedException();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            PauseCanvas.gameObject.SetActive(paused);

        }

        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}
