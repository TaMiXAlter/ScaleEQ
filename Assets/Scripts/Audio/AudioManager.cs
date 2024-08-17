using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    #region Singleton
 
    private static AudioManager instance;

    public static AudioManager Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<AudioManager>();
            }
            return instance;
        }
    }
    
    #endregion
    
    [SerializeField]
    private float RiseModifier = 0.05f;
    [SerializeField]
    private float DropModifier = -0.01f;
    
    AudioSource _audioSource;
    private float[] _samples = new float[512];
    private float[] _freqBand = new float[8];
    public float[] _bandBuffer = new float[8];
    float[] _bufferDelta = new float[8];
    
    private void Awake() => instance = this;

    void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        GetSpectrumAudioSourse();
        MakeFreqBands();
        BandBuffer();
    }
    
    void GetSpectrumAudioSourse() {
        _audioSource.GetSpectrumData(_samples,0,FFTWindow.Blackman);
    }
    void MakeFreqBands() {
        int count = 0;

        for (int i = 0; i < 8; i++) {
            float average = 0;
            int sampleCount = (int) Math.Pow(2, i+1);
            if (i == 7) {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++) {
                average += _samples[count] * (count + 1);
                count++;
            }
            _freqBand[i] = average / count;
        }
    }
    void BandBuffer() {
        for (int i = 0; i < 8; i++) {
            if(Mathf.Approximately(_freqBand[i], _bandBuffer[i])) continue;
            if (_freqBand[i] > _bandBuffer[i]) _bufferDelta[i] = (_freqBand[i]-_bandBuffer[i])* RiseModifier;
            if (_freqBand[i] < _bandBuffer[i]) _bufferDelta[i] = (_bandBuffer[i]-_freqBand[i])* DropModifier;
            _bandBuffer[i] += _bufferDelta[i];
        }   
    }
}
