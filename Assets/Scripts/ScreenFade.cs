using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    [SerializeField, Tooltip("The image source that should be faded.")] Image image = null;
    [SerializeField, Tooltip("A time in seconds to control the length of the fade.")] float time;
    [SerializeField, Tooltip("The color to start with on fade in.")] Color startColor;
    [SerializeField, Tooltip("The color to end with on fade in.")] Color endColor;
    [SerializeField, Tooltip("If true will fade in automatically on Awake.")] bool startOnAwake = true;
    
    /// <summary>
    /// isDone tracks when the fading is finished, it will be false if there is a fade actively occuring.
    /// </summary>
    public bool isDone { get; set; } = false;

    void Start()
    {
        if (startOnAwake)
        {
            FadeIn();
        }
    }

    /// <summary>
    /// FadeIn will fade a scene in for a given time.
    /// </summary>
    /// <param name="time">Defaults to 0, if time is 0 it will use the ScreenFade time property.</param>
    public void FadeIn(float time = 0)
	{
        isDone = false;
        image.gameObject.SetActive(true);

        StartCoroutine(FadeRoutine(startColor, endColor, time == 0 ? this.time : time));
    }

    /// <summary>
    /// FadeOut will fade a scene out for a given time.
    /// </summary>
    /// <param name="time">Defaults to 0, if time is 0 it will use the ScreenFade time property.</param>
    /// <param name="deactivate">Defaults to true. Determines if the image object is active after the FadeOut</param>
    public void FadeOut(float time = 0, bool deactivate = true)
    {
        
        isDone = false;
        image.gameObject.SetActive(true);

        StartCoroutine(FadeRoutine(endColor, startColor, time == 0 ? this.time : time, deactivate));
    }

    /// <summary>
    /// A coroutine used to perform the fade.
    /// </summary>
    /// <param name="color1">The initial Color state of the image object.</param>
    /// <param name="color2">The Color state of the image object after the fade.</param>
    /// <param name="time">How long the fade will be</param>
    /// <param name="deactivate">Defaults to true. Determines if the image object is active after the fade</param>
    IEnumerator FadeRoutine(Color color1, Color color2, float time, bool deactivate = true)
    {
        float timer = 0;
        while (timer < time)
        {
            timer = timer + Time.unscaledDeltaTime;
            image.color = Color.Lerp(color1, color2, timer/time);

            yield return null;
        }

        if(deactivate) image.gameObject.SetActive(false);
        isDone = true;
    }
}
