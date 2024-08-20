using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUIManager : MonoBehaviour
{
    Button Button1,Button2,Button3;
   
    void Start()
    {
       Button1 = transform.Find("B_Level1").GetComponent<Button>();
       Button2 = transform.Find("B_Level2").GetComponent<Button>();
       Button3 = transform.Find("B_Level3").GetComponent<Button>();
       
       Button1.onClick.AddListener(() => { GameManager.Instance.ChangeScene("Level-One"); });
       Button2.onClick.AddListener(() => { GameManager.Instance.ChangeScene("Level-Two"); });
       // Button3.onClick.AddListener(() => { GameManager.Instance.ChangeScene("Level3"); });
    }
    
    
}
