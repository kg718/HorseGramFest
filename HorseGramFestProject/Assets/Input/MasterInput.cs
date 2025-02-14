//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input/MasterInput.inputactions
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

public partial class @MasterInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MasterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""c341432c-dc6c-43eb-b3d9-2b71f90c20b2"",
            ""actions"": [
                {
                    ""name"": ""Booster1"",
                    ""type"": ""Button"",
                    ""id"": ""d1f48b79-36a5-44fa-8066-fce357d5ea60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Booster2"",
                    ""type"": ""Button"",
                    ""id"": ""4280fc9b-14e4-4f1f-956c-02550493f11d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Booster3"",
                    ""type"": ""Button"",
                    ""id"": ""5b829a44-80b4-4a65-be0f-88abccc880b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Booster4"",
                    ""type"": ""Button"",
                    ""id"": ""1296f9c3-c575-4d36-8682-6fac289752b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f8bbd057-a4ea-47ed-b282-de1a22d6bae1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6e10652d-37d3-48f1-8850-47aba2281bc6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Booster1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a05df58c-0419-45dc-ab57-da8de52bdfd7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Booster1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d223f49-a481-4cf2-8ba7-e9475e182bae"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Booster2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa5a9c83-a2c1-4672-a800-3d6159d7b54e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Booster2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93c5e765-1b2f-4432-94c1-f83b67ce0b37"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Booster3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66044121-490d-461f-a1dd-6f4ba54d7b54"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Booster3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0312ab7f-ad12-4c68-8217-e3672d06621d"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Booster4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a3cd9d0-4e0c-4aaf-920b-f8f9f2b28c9e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Booster4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""358a01fc-1449-4d12-8fb0-aeb2e5b5f9da"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4a7600b-38c2-473f-8cd4-c55c49db4590"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Booster1 = m_Player.FindAction("Booster1", throwIfNotFound: true);
        m_Player_Booster2 = m_Player.FindAction("Booster2", throwIfNotFound: true);
        m_Player_Booster3 = m_Player.FindAction("Booster3", throwIfNotFound: true);
        m_Player_Booster4 = m_Player.FindAction("Booster4", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Booster1;
    private readonly InputAction m_Player_Booster2;
    private readonly InputAction m_Player_Booster3;
    private readonly InputAction m_Player_Booster4;
    private readonly InputAction m_Player_Pause;
    public struct PlayerActions
    {
        private @MasterInput m_Wrapper;
        public PlayerActions(@MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Booster1 => m_Wrapper.m_Player_Booster1;
        public InputAction @Booster2 => m_Wrapper.m_Player_Booster2;
        public InputAction @Booster3 => m_Wrapper.m_Player_Booster3;
        public InputAction @Booster4 => m_Wrapper.m_Player_Booster4;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Booster1.started += instance.OnBooster1;
            @Booster1.performed += instance.OnBooster1;
            @Booster1.canceled += instance.OnBooster1;
            @Booster2.started += instance.OnBooster2;
            @Booster2.performed += instance.OnBooster2;
            @Booster2.canceled += instance.OnBooster2;
            @Booster3.started += instance.OnBooster3;
            @Booster3.performed += instance.OnBooster3;
            @Booster3.canceled += instance.OnBooster3;
            @Booster4.started += instance.OnBooster4;
            @Booster4.performed += instance.OnBooster4;
            @Booster4.canceled += instance.OnBooster4;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Booster1.started -= instance.OnBooster1;
            @Booster1.performed -= instance.OnBooster1;
            @Booster1.canceled -= instance.OnBooster1;
            @Booster2.started -= instance.OnBooster2;
            @Booster2.performed -= instance.OnBooster2;
            @Booster2.canceled -= instance.OnBooster2;
            @Booster3.started -= instance.OnBooster3;
            @Booster3.performed -= instance.OnBooster3;
            @Booster3.canceled -= instance.OnBooster3;
            @Booster4.started -= instance.OnBooster4;
            @Booster4.performed -= instance.OnBooster4;
            @Booster4.canceled -= instance.OnBooster4;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnBooster1(InputAction.CallbackContext context);
        void OnBooster2(InputAction.CallbackContext context);
        void OnBooster3(InputAction.CallbackContext context);
        void OnBooster4(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
