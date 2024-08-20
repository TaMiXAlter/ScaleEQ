using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUIManager : MonoBehaviour
{
    Button Button1,Button2,Button3,ButtonHome;
   
    void Start()
    {
       Button1 = transform.Find("B_Level1").GetComponent<Button>();
       Button2 = transform.Find("B_Level2").GetComponent<Button>();
       Button3 = transform.Find("B_Level3").GetComponent<Button>();
       ButtonHome = transform.Find("B_Home").GetComponent<Button>();
       
       Button1.onClick.AddListener(() => { GameManager.Instance.ChangeScene("Level-1"); });
       Button2.onClick.AddListener(() => { GameManager.Instance.ChangeScene("Level-2"); });
       Button3.onClick.AddListener(() => { GameManager.Instance.ChangeScene("Level-3"); });
       ButtonHome.onClick.AddListener(() => { GameManager.Instance.ChangeScene("MainMenu"); });
    }

    private void OnDisable()
    {
        Button1.onClick.RemoveAllListeners();
        Button2.onClick.RemoveAllListeners();
        Button3.onClick.RemoveAllListeners();
        ButtonHome.onClick.RemoveAllListeners();
    }
}
