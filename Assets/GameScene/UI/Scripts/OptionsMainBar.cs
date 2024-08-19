using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionsMainBar : MonoBehaviour
{

    //for the QUIT / HOME / PLAY buttons 
    [System.Serializable]
    public struct mainButtons //for the main buttons
    {
      public Button button;
      public Sprite normalSprite;
      public Sprite pressedSprite;
    }

    public mainButtons[] buttons;
    private mainButtons currentButton;

    public void OnButtonPressed(int index)
    {
        ActivateButton(buttons[index]);

        switch(index)
        {
            case 0: //quit
                Application.Quit();
                break;
            case 1: //home
                SceneManager.LoadSceneAsync("MainMenu"); 
                break;
            case 2: //play
                SceneManager.LoadSceneAsync("idk"); //idk! 
                break;
            default: 
                break;

        }
    }

    private void ActivateButton(mainButtons newButton)
    {
        if(currentButton.button != null)
        {
            currentButton.button.image.sprite = currentButton.normalSprite;
        }
        currentButton = newButton;
        currentButton.button.image.sprite = currentButton.pressedSprite;
    }
  
}
