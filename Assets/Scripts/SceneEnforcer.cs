using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// SceneEnforcer is used to forcibly load a scene.
/// </summary>
public class SceneEnforcer : MonoBehaviour
{
	[SerializeField, Tooltip("The name of the scene to be loaded")] string sceneName;
	[SerializeField, Tooltip("How to load the scene. Single will simply load the scene, Additive will load the scene alongside the current scene.")] LoadSceneMode mode;

	/// <summary>
	/// Will load the scene specified by the sceneName field as long as it is not already loaded.
	/// </summary>
	private void Awake()
	{
		if (!isSceneLoaded(sceneName))
		{
			SceneManager.LoadScene(sceneName, mode);
		} 
	}

	/// <summary>
	/// Will check to see if the scene is already loaded.
	/// </summary>
	/// <param name="sceneName">The name of the scene to be checked for.</param>
	/// <returns>True if the scene was successfully loaded.</returns>
    public static bool isSceneLoaded(string sceneName)
	{
		// check loaded scenes for matching scene name
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			var scene = SceneManager.GetSceneAt(i);
			if (scene.name == sceneName)
			{
				return true;
			}
		}

		return false;
	}
}
