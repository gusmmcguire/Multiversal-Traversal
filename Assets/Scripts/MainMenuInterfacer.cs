using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuInterfacer : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;

    public void SeeSettings()
    {
        GameManager.Instance.gameObject.GetComponent<ScreenFade>().FadeOut();
        MenuManager.Instance.SeeSettings();
    }
    
    public void SeeMainMenu()
    {
        GameManager.Instance.gameObject.GetComponent<ScreenFade>().FadeOut(.25f);
        StartCoroutine(GoToMainMenu());
    }

    public void SeeCredits()
    {
        GameManager.Instance.gameObject.GetComponent<ScreenFade>().FadeOut(.25f);
        StartCoroutine(GoToCredits());
    }

    public void SeeControls()
    {
        GameManager.Instance.gameObject.GetComponent<ScreenFade>().FadeOut();
        MenuManager.Instance.SeeControls();
    }

    public void StartGameFromScene(string sceneName)
    {
        GameManager.Instance.pauser.canPause = true;
        GameManager.Instance.OnLoadScene(sceneName);
    }

    public void QuitGame()
    {
        GameManager.Instance.gameObject.GetComponent<ScreenFade>().FadeOut();
        MenuManager.Instance.QuitGame();
    }

    IEnumerator GoToMainMenu()
    {
        yield return new WaitUntil(() => GameManager.Instance.gameObject.GetComponent<ScreenFade>().isDone);
        GameManager.Instance.gameObject.GetComponent<ScreenFade>().FadeIn(.25f);
        MenuManager.Instance.EnsureAllUIOff();
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    IEnumerator GoToCredits()
    {
        yield return new WaitUntil(() => GameManager.Instance.gameObject.GetComponent<ScreenFade>().isDone);
        GameManager.Instance.gameObject.GetComponent<ScreenFade>().FadeIn(.25f);
        MenuManager.Instance.EnsureAllUIOff();
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
}
