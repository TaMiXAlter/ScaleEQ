using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinView:GamePlayUIView
    {
        [SerializeField]
        GameObject Egg;
        float SpawnEggAmout = 0;
        [SerializeField] float Spacing = 5f;
        Button Restart, Home;
        public void SetWinData(float playerRemainingHealth)
        {
            SpawnEggAmout = playerRemainingHealth;
        }

        private void OnEnable()
        {
            for (int i = 0; i < SpawnEggAmout; i++) {
                GameObject egg = Instantiate(Egg, transform);
                egg.transform.localPosition =  new Vector3(Spacing * i, 0, 0);
            }
            
            Restart = transform.Find("Restart").GetComponent<Button>();
            Home = transform.Find("Home").GetComponent<Button>();
            
            Restart.onClick.AddListener(() => { GameManager.Instance.ChangeScene(GameManager.Instance.CurrentSceneName); });
            Home.onClick.AddListener(() => { GameManager.Instance.ChangeScene("MainMenu"); });
        }

        private void OnDisable()
        {
            Restart.onClick.RemoveAllListeners();
            Home.onClick.RemoveAllListeners();
        }
    }
}