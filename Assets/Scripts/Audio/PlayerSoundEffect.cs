using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSoundEffect : MonoBehaviour
{
    private AudioSource AudioSource;

    [Header("Borad")] [SerializeField] private AudioClip Sliding;
    [SerializeField] private AudioClip[] Jumps;
    [SerializeField] private AudioClip[] Landings;
    [SerializeField] private AudioClip[] Charges;
    [SerializeField] private AudioClip[] Realease;
    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void ToggleSlide(bool toggle)
    {
        if (toggle)
        {
            AudioSource.clip = Sliding;
            AudioSource.loop = true;
            AudioSource.Play();
            return;
        }
        
        AudioSource.loop = false;
        AudioSource.Pause();
    }

    public void PlayJump()
    {
        AudioClip targetClip = Jumps[Random.Range(0, Jumps.Length)];
        AudioSource.PlayOneShot(targetClip);
    }
    
    public void PlayLand()
    {
        AudioClip targetClip = Landings[Random.Range(0, Landings.Length)];
        AudioSource.PlayOneShot(targetClip);
    }
    
    public void PlayCharge()
    {
        AudioClip targetClip = Charges[Random.Range(0, Charges.Length)];
        AudioSource.PlayOneShot(targetClip);
    }
    
    public void PlayRealease()
    {
        AudioClip targetClip = Realease[Random.Range(0, Realease.Length)];
        AudioSource.PlayOneShot(targetClip);
    }
}
