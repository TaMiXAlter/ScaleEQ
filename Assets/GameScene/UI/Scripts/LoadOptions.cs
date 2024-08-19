using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOptions : MonoBehaviour
{
    
    public void LoadOptionsPage() 
    {
        //i hardcoded bc idk how u guys will order the scene in build
        SceneManager.LoadScene("Options");
    }
}
