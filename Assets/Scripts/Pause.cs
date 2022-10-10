using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] AudioClip openPause;
    [SerializeField] AudioClip closePause;
    public bool canPause = true;

    bool isPaused = false;

    public bool paused
    {
        get { return isPaused; }
        set
        {
            if (!canPause) return;
            isPaused = value;
            pauseUI.SetActive(isPaused);
            Time.timeScale = (isPaused) ? 0 : 1;
            if(openPause && closePause)
                if (value) AudioManager.Instance.PlaySFX(openPause);
                else AudioManager.Instance.PlaySFX(closePause);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            
        }
    }
}