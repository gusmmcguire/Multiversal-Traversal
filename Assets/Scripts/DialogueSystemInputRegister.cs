using UnityEngine;
using UnityEngine.InputSystem;
using PixelCrushers;

public class DialogueSystemInputRegister : MonoBehaviour // Add me to Dialogue Manager.
{
    GameControls controls;

    protected static bool isRegistered = false;
    private bool didIRegister = false;

    void Awake()
    {
        controls = new GameControls();
    }

    void OnEnable()
    {
        if (!isRegistered)
        {
            isRegistered = true;
            didIRegister = true;
            controls.Enable();
            //register each action dialogue manager needs to know
            InputDeviceManager.RegisterInputAction("Interact", controls.InGame.Interact);
        }
    }

    void OnDisable()
    {
        if (didIRegister)
        {
            isRegistered = false;
            didIRegister = false;
            controls.Disable();
            InputDeviceManager.UnregisterInputAction("Interact");
        }
    }
}