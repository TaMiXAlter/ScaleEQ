
using UnityEngine;
using UnityEngine.Audio;

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
     
    private AudioFrequency audioFrequency;
    [SerializeField]
    AudioMixer MasterMixer;
    private void Awake() {
        instance = this;
        audioFrequency = gameObject.AddComponent<AudioFrequency>();
    }
    public float[] GetAudioBuffer() {
       return audioFrequency._bandBuffer;
    }

    public void SetEQ(float freq, float gain) {
        MasterMixer.SetFloat("Gain", gain);
        MasterMixer.SetFloat("Freq", freq);
    }
}
