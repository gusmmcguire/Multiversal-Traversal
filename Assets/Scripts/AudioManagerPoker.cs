using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The <c>AudioManagerPoker</c> is intended for use when the <c>AudioManager</c> cannot be reached by reasonable means. For example, in the case where a button clicked needs to produce a noise,
/// but the button is contained within a scene seperate from the AudioManager.
/// </summary>
public class AudioManagerPoker : MonoBehaviour
{
    #region PUBLIC METHODS

    /// <summary>
    /// PlaySFX takes in an AudioClip and plays it using the SFX Audio Source set in the AudioManager.
    /// </summary>
    /// <param name="audioClip">The AudioClip to be played.</param>
    public void PlaySFX(AudioClip audioClip)
    {
        AudioManager.Instance.PlaySFX(audioClip);
    }

    /// <summary>
    /// PlayMusic takes in an AudioClip and plays it using the Music Audio Source set in the AudioManager.
    /// </summary>
    /// <param name="audioClip">The AudioClip to be played.</param>
    public void PlayMusic(AudioClip audioClip)
    {
        AudioManager.Instance.PlayMusic(audioClip);
    }

    #endregion
}