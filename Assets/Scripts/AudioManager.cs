using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager _instance = null;

    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                    Debug.Log("AudioManager is nowhere");
            }
            return _instance;
        }
    }

    private AudioSource MusicSource;
    private AudioSource EffectSource;

    private float LowPitch = 0.95f;
    private float HighPitch = 1.00f;

    public void PlayerMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitch, HighPitch);

        EffectSource.pitch = randomPitch;
        EffectSource.clip = clips[randomIndex];
        EffectSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
}
