using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseView : GamePlayUIView
    {
        [SerializeField]
        Button Resume, Restart, Home;
        void OnEnable()
        {
            Resume = transform.Find("Resume").GetComponent<Button>();
            Restart = transform.Find("Restart").GetComponent<Button>();
            Home = transform.Find("Home").GetComponent<Button>();
            Resume.onClick.AddListener(() => { AudioManager.Instance.TogglePlay(true); GameSceneManager.Instance.state = GameSceneManager.GameState.GameStart; Hide(); });
            Restart.onClick.AddListener(() =>
            {
                GameManager.Instance.ChangeScene(GameManager.Instance.CurrentSceneName);
                GameSceneManager.Instance.StartTime = Time.time;
            });
            Home.onClick.AddListener(() => { GameManager.Instance.ChangeScene("MainMenu"); });
        }

        private void OnDisable()
        {
            Resume.onClick.RemoveAllListeners();
            Restart.onClick.RemoveAllListeners();
            Home.onClick.RemoveAllListeners();
        }
    }
}