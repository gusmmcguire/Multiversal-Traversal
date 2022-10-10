using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// The AudioManager manages the audio for the project. It contains information about volume levels, audio sources, and an audio mixer. It can be accessed from any script at any time, provided there
/// is an instance of the AudioManager< script in any given scene.
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    #region PROPERTIES EXPOSED TO THE INSPECTOR
    
    [Header("Audio Data")]
    [SerializeField, Tooltip("This AudioMixer should have 2 sub-groups, a Music and a SFX group.")] AudioMixer audioMixer;
    [SerializeField, Tooltip("This GameData object should be unique and store the master, music, and sfx volumes as float values.")] GameData audioData;
    
    [Header("Audio Sources")]
    [SerializeField, Tooltip("An audio source that uses the music group of the audio mixer.")] AudioSource musicAudioSource;
    [SerializeField, Tooltip("An audio source that uses the SFX group of the audio mixer.")] AudioSource sfxAudioSource;

    #endregion

    #region CONSTANT FIELDS

    const string MASTER_VOLUME = "MasterVolume";
    const string SFX_VOLUME = "SFXVolume";
    const string MUSIC_VOLUME = "MusicVolume";

    #endregion

    #region PUBLIC PROPERTIES

    /// <summary>
    /// Setting MasterVolume will convert a percentile value from 0 to 1 to a decible value for the AudioMixer.
    /// Getting MasterVolume will convert the stored decible value to a percentile value from 0 to 1.
    /// </summary>
    public float MasterVolume
    {
        get
        {
            audioMixer.GetFloat(MASTER_VOLUME, out float dB);
            return DBToLinear(dB);
        }
        set
        {
            float dB = LinearToDB(value);
            audioMixer.SetFloat(MASTER_VOLUME, dB);
            audioData.floatData[MASTER_VOLUME] = value;
        }
    }

    /// <summary>
    /// Setting SFXVolume will convert a percentile value from 0 to 1 to a decible value for the AudioMixer.
    /// Getting SFXVolume will convert the stored decible value to a percentile value from 0 to 1.
    /// </summary>
    public float SFXVolume
    {
        get
        {
            audioMixer.GetFloat(SFX_VOLUME, out float dB);
            return DBToLinear(dB);
        }
        set
        {
            float dB = LinearToDB(value);
            audioMixer.SetFloat(SFX_VOLUME, dB);
            audioData.floatData[SFX_VOLUME] = value;
        }
    }

    /// <summary>
    /// Setting MusicVolume will convert a percentile value from 0 to 1 to a decible value for the AudioMixer.
    /// Getting MusicVolume will convert the stored decible value to a percentile value from 0 to 1.
    /// </summary>
    public float MusicVolume
    {
        get
        {
            audioMixer.GetFloat(MUSIC_VOLUME, out float dB);
            return DBToLinear(dB);
        }
        set
        {
            float dB = LinearToDB(value);
            audioMixer.SetFloat(MUSIC_VOLUME, dB);
            audioData.floatData[MUSIC_VOLUME] = value;
        }
    }

    #endregion

    #region UNITY MESSAGES

    void Start()
    {
        MasterVolume = audioData.floatData[MASTER_VOLUME];
        SFXVolume = audioData.floatData[SFX_VOLUME];
        MusicVolume = audioData.floatData[MUSIC_VOLUME];
    }

    #endregion

    #region PUBLIC METHODS

    /// <summary>
    /// PlaySFX takes in an AudioClip and plays it using the SFX Audio Source set in the AudioManager.
    /// </summary>
    /// <param name="clip">The AudioClip to be played.</param>
    public void PlaySFX(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }


    /// <summary>
    /// PlayMusic takes in an AudioClip and plays it using the Music Audio Source set in the AudioManager.
    /// </summary>
    /// <param name="clip">The AudioClip to be played.</param>
    public void PlayMusic(AudioClip clip)
    {
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    #endregion

    #region PRIVATE HELPFER METHODS

    /// <summary>
    /// Takes a percentile value and converts it to a decible value.
    /// </summary>
    /// <param name="linear">A value between 0 and 1 representing a percentile.</param>
    /// <returns></returns>
    private static float LinearToDB(float linear)
    {
        return (linear != 0) ? 20.0f * Mathf.Log10(linear) : -144.0f;
    }

    /// <summary>
    /// Takes a decible value and converts it to a percentile value from 0 to 1.
    /// </summary>
    /// <param name="dB">A value representing a decible.</param>
    /// <returns></returns>
    private static float DBToLinear(float dB)
    {
        return Mathf.Pow(10.0f, dB / 20.0f);
    }
    #endregion
}

