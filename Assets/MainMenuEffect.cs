using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainMenuEffect : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip[] ButtonCliks;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonClick()
    {
        int index = Random.Range(0, ButtonCliks.Length);
        _audioSource.PlayOneShot(ButtonCliks[index]);
    }
}
