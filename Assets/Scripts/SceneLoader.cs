using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField, Tooltip("The GameObject containing the UI to be displayed while loading.")] GameObject loadingUI;
	[SerializeField, Tooltip("The slider object to visually display the loading percentage.")] Slider loadingMeterUI;
	[SerializeField, Tooltip("The ScreenFade object that controls the fading of the project")] ScreenFade screenFade;

	/// <summary>
	/// Load will will load a scene based upon the sceneName. The scene must be part of the build index.
	/// </summary>
	/// <param name="sceneName">The string representation of the name of the scene to be loaded.</param>
	public void Load(string sceneName)
	{
		StartCoroutine(LoadScene(sceneName));
	}

	/// <summary>
	/// A coroutine called by Load that will handle the load screen and fading in and out.
	/// </summary>
	/// <param name="sceneName">The string representation of the name of the scene to be loaded.</param>
	IEnumerator LoadScene(string sceneName)
	{
		Time.timeScale = 1;

		// fade out screen
		screenFade.FadeOut();
		yield return new WaitUntil(() => screenFade.isDone);

		// load scene
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
		asyncOperation.allowSceneActivation = false;
		//Pause.Instance.paused = false;

		// show loading ui
		loadingUI.SetActive(true);

		// update progress meter
		while (asyncOperation.progress < 0.9f)
		{
			loadingMeterUI.value = asyncOperation.progress;
			yield return null;
		}
		loadingMeterUI.value = 1;
		yield return new WaitForSeconds(1);

		// hide loading ui
		loadingUI.SetActive(false);
		
		// scene loaded / start
		asyncOperation.allowSceneActivation = true;

		// fade in screen
		screenFade.FadeIn();
		yield return new WaitUntil(() => screenFade.isDone);
	}
}
