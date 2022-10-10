using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : Singleton<SettingsManager>
{
    /// <summary>
    /// eResolution is an enum type used for converting from a dropdown menu selection to direct resolution values.
    /// </summary>
    public enum eResolution
    {
        SEVEN_TWENTY = 0,
        TEN_EIGHTY = 1,
        FOUR_K = 2
    }

    /// <summary>
    /// isFullscreen can be used to determine if the game is currently in Fullscreen mode or not
    /// </summary>
    public bool isFullscreen { get; set; }

    /// <summary>
    /// UpdateResolution can be called to update the current resolution of the game based upon the resolutionSelection dropdown menu.
    /// </summary>
    /// <param name="resolutionSelection">A UI Text Mesh Pro Dropdown menu that contains resolution options</param>
    public void UpdateResolution(TMP_Dropdown resolutionSelection)
    {
        switch ((eResolution)resolutionSelection.value)
        {
            case eResolution.SEVEN_TWENTY:
                Screen.SetResolution(1280, 720, isFullscreen);
                break;
            case eResolution.TEN_EIGHTY:
                Screen.SetResolution(1920, 1080, isFullscreen);
                break;
            case eResolution.FOUR_K:
                Screen.SetResolution(3840, 2160, isFullscreen);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// UpdateFullscreen will take in a toggle component that is used to determine what the fullscreen state should be.
    /// </summary>
    /// <param name="fullscreenToggle">The toggle component that controls the state of fullscreen</param>
    public void UpdateFullscreen(Toggle fullscreenToggle)
    {
        isFullscreen = fullscreenToggle.isOn;
        Screen.fullScreen = isFullscreen;
    }
}
