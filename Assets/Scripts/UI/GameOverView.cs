using System;
using UnityEngine.UI;

namespace UI
{
    public class GameOverView:GamePlayUIView
    {
        private Button Restart, Quit;

        private void OnEnable()
        {
            Restart = transform.Find("Restart").GetComponent<Button>();
            Quit = transform.Find("Quit").GetComponent<Button>();
            
            Restart.onClick.AddListener(() => { GameManager.Instance.ChangeScene(GameManager.Instance.CurrentSceneName); });
            Quit.onClick.AddListener(() => { GameManager.Instance.ChangeScene("LevelSelect"); });
        }

        private void OnDisable()
        {
            Restart.onClick.RemoveAllListeners();
            Quit.onClick.RemoveAllListeners();
        }
    }
}