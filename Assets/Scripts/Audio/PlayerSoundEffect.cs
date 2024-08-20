using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSoundEffect : MonoBehaviour
{
    private AudioSource MovementAudioSource,SlidingAudioSource;
    [SerializeField] private float SlidingModify;
    
    [Header("Borad")] [SerializeField] private AudioClip Sliding;
    [SerializeField] private AudioClip[] Jumps;
    [SerializeField] private AudioClip[] Landings;
    [SerializeField] private AudioClip[] Charges;
    [SerializeField] private AudioClip[] Realease;
    
    [Header("health")][SerializeField]private AudioClip[] hurt;
    [SerializeField]private AudioClip[] dead;
    private void Awake()
    {
        MovementAudioSource = GetComponent<AudioSource>();
        SlidingAudioSource = transform.Find("Sliding").GetComponent<AudioSource>();
        SlidingAudioSource.clip = Sliding;
    }
    
    public void SetSlideValue(float value)
    {
        if (value <=0) {
            SlidingAudioSource.Pause();
            return;
        }
        
        if (!SlidingAudioSource.isPlaying) SlidingAudioSource.Play();
        SlidingAudioSource.volume = value*SlidingModify;
    }

    public void PlayJump()
    {
        MovementAudioSource.Stop();
        AudioClip targetClip = Jumps[Random.Range(0, Jumps.Length)];
        MovementAudioSource.PlayOneShot(targetClip);
        
    }
    
    public void PlayLand()
    {
        MovementAudioSource.Stop();
        AudioClip targetClip = Landings[Random.Range(0, Landings.Length)];
        MovementAudioSource.PlayOneShot(targetClip);
       
        
    }
    
    public void PlayCharge()
    {
        MovementAudioSource.Stop();
        AudioClip targetClip = Charges[Random.Range(0, Charges.Length)];
        if (targetClip)
        {
            MovementAudioSource.PlayOneShot(targetClip);
        }
    }
    
    public void PlayRealease()
    {
        MovementAudioSource.Stop();
        AudioClip targetClip = Realease[Random.Range(0, Realease.Length)];
        if (targetClip)
        {
            MovementAudioSource.PlayOneShot(targetClip);
        }
    }
    
    public void PlayHurt()
    {
        MovementAudioSource.Stop();
        AudioClip targetClip = hurt[Random.Range(0, hurt.Length)];
        if (targetClip)
        {
            MovementAudioSource.PlayOneShot(targetClip);
        }
    }
    
    public void PlayDead()
    {
        MovementAudioSource.Stop();
        AudioClip targetClip = dead[Random.Range(0, dead.Length)];
        if (targetClip)
        {
            MovementAudioSource.PlayOneShot(targetClip);
        }
    }
}
