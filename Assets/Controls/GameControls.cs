//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Controls/GameControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""In Game"",
            ""id"": ""b52d38fb-2adc-4a2e-b827-f73514d7f722"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2797d9d6-ef2d-4b5d-974d-7c786b16a88a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""486f0a8c-cbea-4a31-aaac-ff3022b77526"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""04a5dfe7-cbc8-4ad0-be4e-b65b87e343f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""eebde52a-ccd7-492e-8c6b-14a087c7dfd8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""cfafd6ad-b679-4237-ae78-3e939ee995d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""48ceff9f-6490-43bf-8e48-e6a9c5a9fef6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f3b264e-60e6-4fb4-a9ce-44305cf2e376"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f027909e-0c78-498f-a228-97fd18feaa32"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7ff42b4-57be-40da-b0ed-ba379d189816"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""b99a4dec-c78f-4766-b250-0effb4e00c39"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8f4c07f5-4be9-4b03-ad04-10f573a98631"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""988e1233-258f-4087-b84e-f79e200d1b74"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""233ac7bf-b76d-42af-b1ba-ee3cf603eb97"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d32839a7-6608-47d2-a585-f87a0c425a88"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9333ffa5-04f6-42f2-bd7b-d42555356d09"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a11210e4-22ab-48b0-b516-765a8c446ac5"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a465ede-a662-438a-af9a-17594f638f2f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // In Game
        m_InGame = asset.FindActionMap("In Game", throwIfNotFound: true);
        m_InGame_Move = m_InGame.FindAction("Move", throwIfNotFound: true);
        m_InGame_Run = m_InGame.FindAction("Run", throwIfNotFound: true);
        m_InGame_Interact = m_InGame.FindAction("Interact", throwIfNotFound: true);
        m_InGame_Jump = m_InGame.FindAction("Jump", throwIfNotFound: true);
        m_InGame_Pause = m_InGame.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // In Game
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_Move;
    private readonly InputAction m_InGame_Run;
    private readonly InputAction m_InGame_Interact;
    private readonly InputAction m_InGame_Jump;
    private readonly InputAction m_InGame_Pause;
    public struct InGameActions
    {
        private @GameControls m_Wrapper;
        public InGameActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_InGame_Move;
        public InputAction @Run => m_Wrapper.m_InGame_Run;
        public InputAction @Interact => m_Wrapper.m_InGame_Interact;
        public InputAction @Jump => m_Wrapper.m_InGame_Jump;
        public InputAction @Pause => m_Wrapper.m_InGame_Pause;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnRun;
                @Interact.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnInteract;
                @Jump.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                @Pause.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IInGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
