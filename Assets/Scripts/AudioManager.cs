using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource[] MusicSource;
    public AudioClip Background;
    public AudioClip RainDrop;
    public AudioClip RainCol;
    public AudioClip Fire;
    public AudioClip Bomb;

    public int MusicCount = 0;

    // Random pitch adjustment range.
    public float BackgroundSound = 1.0f;
    public float EffectSound = 1.0f;
    public float LowPitch = 0.95f;
    public float HighPitch = 1.05f;

    public static AudioManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        if (MusicCount >= MusicSource.Length)
            return;

        MusicSource[MusicCount].clip = clip;
        MusicSource[MusicCount].Play();

        MusicCount++;
    }

    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(AudioClip clips)
    {
        float randomPitch = Random.Range(LowPitch, HighPitch);

        EffectsSource.pitch = randomPitch;
        EffectsSource.clip = clips;
        EffectsSource.Play();
    }

    public void AudioRun()
    {
        foreach (AudioSource item in MusicSource)
        {
            try
            {

                item.volume = BackgroundSound;
            }
            catch (NullReferenceException ex)
            {
                Debug.Log(ex);
            }
        }
        EffectsSource.volume = EffectSound;
    }

}