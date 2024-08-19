using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
  [System.Serializable]
    public struct ButtonData  //for the settings buttons
    {
      public Button button;
      public Sprite normalSprite;
      public Sprite pressedSprite;
      public GameObject panel;
    }

    public ButtonData[] buttons; 
    private ButtonData currentButton;    

    void Start()
    {
      ActivateButton(buttons[0]); //should be audio tab
    }

    public void OnButtonPressed(int index)
    {
      ActivateButton(buttons[index]);
    }

    private void ActivateButton(ButtonData newButton)
    {
      if(currentButton.button != null)
      {
        currentButton.button.image.sprite = currentButton.normalSprite;
        currentButton.panel.SetActive(false);
      }

      currentButton = newButton;
      currentButton.button.image.sprite = currentButton.pressedSprite;
      currentButton.panel.SetActive(true);
    }

}
