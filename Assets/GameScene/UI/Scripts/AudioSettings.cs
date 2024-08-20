using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    private Slider masterSlider, musicSlider, sfxSlider; 

    private void Start()
    {
        masterSlider = transform.Find("master").GetComponent<Slider>();
        musicSlider = transform.Find("music").GetComponent<Slider>();
        sfxSlider = transform.Find("sfx").GetComponent<Slider>();
        
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }
    

    private void OnDestroy()
    {
        masterSlider.onValueChanged.RemoveAllListeners();
        musicSlider.onValueChanged.RemoveAllListeners();
        sfxSlider.onValueChanged.RemoveAllListeners();
    }

    private void SetSFXVolume(float arg0)
    {
        mixer.SetFloat("SFX",Mathf.Lerp(-30,10, arg0));
    }

    private void SetMusicVolume(float arg0)
    {
        mixer.SetFloat("Music",Mathf.Lerp(-30,10, arg0));
    }

    private void SetMasterVolume(float arg0)
    {
        mixer.SetFloat("Master",Mathf.Lerp(-30,10, arg0));
    }

   
}
