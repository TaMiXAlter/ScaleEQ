using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderButtom : MonoBehaviour
{
    [SerializeField]
    private Button play, home;
    

    private void OnEnable()
    {
        home.onClick.AddListener(() => { GameManager.Instance.ChangeScene("MainMenu"); });
        play.onClick.AddListener(() => { AudioManager.Instance.TogglePlay(true);});
    }

    private void OnDisable()
    {
        play.onClick.RemoveAllListeners();
        home.onClick.RemoveAllListeners();
    }
}
