using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// The GameManager manages  for the project. It contains information about the game and handles scene loading. 
/// It can be accessed from any script at any time, provided there
/// is an instance of the GameManager script in any given scene.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    #region ENUMS
    
    /// <summary>
    /// An Enumeration type that indicates the current state of the game (eg. GAME_WIN or MAIN_MENU).
    /// This can be expanded or reduced depending on the needs of your project.
    /// </summary>
    public enum State
    {
        PLAYER_START,
        GAME,
        GAME_OVER,
        GAME_WIN,
        MAIN_MENU
    }

    #endregion

    #region PROPERTIES EXPOSED TO THE INSPECTOR

    [Header("Scene")]
    [SerializeField, Tooltip("This should be a SceneLoader component on the same object as the GameManager.")] SceneLoader sceneLoader;

    [Header("User Interface")]
    [SerializeField, Tooltip("A GameObject that is the parent object of all the UI related to a win screen. This will be activated when the player wins.")] GameObject winUI;
    [SerializeField, Tooltip("A GameObject that is the parent object of all the UI related to a lose screen. This will be activated when the player loses.")] GameObject loseUI;

    [Header("Audio Clips")]
    [SerializeField, Tooltip("Music to play upon game loss.")] AudioClip loseMusic;
    [SerializeField, Tooltip("Music to play upon game win.")] AudioClip winMusic;

    #endregion

    #region PUBLIC FIELDS
    [Header("Public Game Data")]
    /// <summary>
    /// This is the Pause component found on the same object as the GameManager.
    /// </summary>
    public Pause pauser;

    /// <summary>
    /// This is a reference to the GameData object in the assets that stores all of the
    /// persistant data that may need accessed during the game.
    /// </summary>
    public GameData gameData;

    /// <summary>
    /// This field tracks the current state of the game. It is assumed that the game will
    /// boot into the MAIN_MENU state, if this is not the case, please change the default state.
    /// </summary>
    public State state = State.MAIN_MENU;

    #endregion

    #region UNITY MESSAGES

    public override void Awake()
    {
        //Calls the Singleton.Awake() method
        base.Awake();       

        //Adds the method OnSceneWasLoaded to the event SceneManager.activeSceneChanged
        SceneManager.activeSceneChanged += OnSceneWasLoaded;
        //Adds a delegate method that calls EndgameUIDisable to the event SceneManager.sceneLoaded
        SceneManager.sceneLoaded += delegate { EndgameUIDisable(); };
    }

    private void Start()
    {
        InitScene();
    }

    private void Update()
    {
        //The GameManager is always loaded in the game, this switch statement
        //will check for what the current state is and execute code based upon
        //that state.
        switch (state)
        {
            case State.MAIN_MENU:
                break;
            case State.PLAYER_START:
                break;
            case State.GAME:
                break;
            case State.GAME_OVER:
                break;
            case State.GAME_WIN:
                break;
            default:
                break;
        }
    }

    #endregion

    #region EVENT CALLS
    /// <summary>
    ///This method is automatically called when a scene loads. 
    /// </summary>
    /// <param name="current">This is the current scene</param>
    /// <param name="next">This is the scene being loaded</param>
    void OnSceneWasLoaded(Scene current, Scene next)
    {
        InitScene();
    }

    #endregion

    #region PUBLIC METHODS

    /// <summary>
    /// This method can be called to load a scene with a specific name.
    /// The name must be exact and the scene must be in the build list.
    /// </summary>
    /// <param name="sceneName">Name of the scene to load.</param>
    public void OnLoadScene(string sceneName)
    {
        sceneLoader.Load(sceneName);
    }

    /// <summary>
    /// This method can be called when the game is lost.
    /// It will display the loseUI GameObject and play the loseMusic AudioClip.
    /// </summary>
    public void OnLose()
    {
        state = State.GAME_OVER;
        loseUI.SetActive(true);
        pauser.paused = false;
        if (loseMusic) AudioManager.Instance.PlayMusic(loseMusic);
    }
    /// <summary>
    /// This method can be called when the game is won.
    /// It will display the winUI GameObject and play the winMusic AudioClip.
    /// </summary>
    public void OnWin()
    {
        state = State.GAME_WIN;
        winUI.SetActive(true);
        pauser.paused = false;
        if (winMusic) AudioManager.Instance.PlayMusic(winMusic);
    }
    #endregion

    #region PRIVATE METHODS

    /// <summary>
    /// This method is called every time a scene is loaded to ensure that the win and lose screens are not displayed by accident.
    /// </summary>
    private void EndgameUIDisable()
    {
        if(winUI) winUI.SetActive(false);
        if(loseUI) loseUI.SetActive(false);
    }

    /// <summary>
    /// InitScene looks for a SceneDescriptor in a newly loaded scene.
    /// If there is a SceneDescriptor, the method will setup the scene accordingly.
    /// </summary>
    private void InitScene()
    {
        SceneDescriptor sceneDescriptor = FindObjectOfType<SceneDescriptor>();
        if (sceneDescriptor != null)
        {
            if (sceneDescriptor.player) Instantiate(sceneDescriptor.player, sceneDescriptor.playerSpawn.position, sceneDescriptor.playerSpawn.rotation);
            if (sceneDescriptor.music) AudioManager.Instance.PlayMusic(sceneDescriptor.music);
        }
    }
    #endregion
}
