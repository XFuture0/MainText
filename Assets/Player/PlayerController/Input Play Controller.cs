//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Player/PlayerController/Input Play Controller.inputactions
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

public partial class @InputPlayController: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputPlayController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input Play Controller"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b613b01a-0bbc-4873-adc5-1eb5c7158842"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""99bf6ebc-7b8b-495c-a131-8a121747778a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c8ea7b97-fce8-4bcb-b73a-8178af69fe48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""a21978d6-765b-4c18-87d6-42ccc318a17a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cash"",
                    ""type"": ""Button"",
                    ""id"": ""2d6dda49-357a-4aa2-b040-b56113d6f35e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftChange"",
                    ""type"": ""Button"",
                    ""id"": ""1f371425-7026-4a9f-a3c4-dce861d7ebb5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightChange"",
                    ""type"": ""Button"",
                    ""id"": ""555be327-3e8c-45e7-9d37-897f0a5ce965"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UP"",
                    ""type"": ""Button"",
                    ""id"": ""1a8b3f2e-cf9b-4a92-9188-f12c5189be67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""581617c6-2d9c-40c1-9253-cb6047104763"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""ca5cf73c-0bff-4a35-a334-d3bfa1e274c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""c4fb11b8-af59-4139-9592-491910cc48c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""886a5837-148e-42e3-a217-f92dcf5259b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5a62919b-87e0-440c-bd7a-150fe2924884"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a68ccf6e-83a7-4620-97c8-ba61cbd248c2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""97118168-8f91-4952-bc09-614ab7c40352"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6f634059-c15a-4907-bf67-af55f8a9da19"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09cd0d3c-91cf-4138-b9cb-9194468d4e43"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e906fef7-7fb7-42b4-a46d-b8b9fa2e322c"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a10843f-e29c-47ac-8ebf-ac41d67a565f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30a62725-7cee-4141-bd80-2c01b0ceab1a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf16609e-c164-4802-959e-09ae84589ecd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79c7d984-c6f5-4fe2-9dee-37d9bc65885e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2552969a-04bd-4fc5-b5e4-f064de3837ea"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1d82c51-d158-4b10-b3d0-90c8976ca177"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a964c66-7334-4574-b28b-7a0b585dfe7d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""ddd72b1d-23c2-40d8-96d2-5661629f31e4"",
            ""actions"": [
                {
                    ""name"": ""In"",
                    ""type"": ""Button"",
                    ""id"": ""03a46e5a-c245-4d21-a665-ae46494d385b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Out"",
                    ""type"": ""Button"",
                    ""id"": ""6e7b051d-4d79-4231-994c-63c6ca01426e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Settings"",
                    ""type"": ""Button"",
                    ""id"": ""057b26b1-756a-4f94-bcfe-3c68ed8f8869"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Stop"",
                    ""type"": ""Button"",
                    ""id"": ""eb31ab67-64a6-47dd-80eb-017822c42acf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1b9c2272-0435-44a3-9217-f407e827ebd9"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""In"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf711018-b0e0-4abb-b66e-c624cc00ebe5"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Out"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea6b0423-4950-4d56-8b8d-7b43bd9af77e"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Settings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64a54ccf-4764-4375-b7bd-7c4db1468295"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stop"",
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
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Press = m_Player.FindAction("Press", throwIfNotFound: true);
        m_Player_Cash = m_Player.FindAction("Cash", throwIfNotFound: true);
        m_Player_LeftChange = m_Player.FindAction("LeftChange", throwIfNotFound: true);
        m_Player_RightChange = m_Player.FindAction("RightChange", throwIfNotFound: true);
        m_Player_UP = m_Player.FindAction("UP", throwIfNotFound: true);
        m_Player_Down = m_Player.FindAction("Down", throwIfNotFound: true);
        m_Player_Throw = m_Player.FindAction("Throw", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Enter = m_Player.FindAction("Enter", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_In = m_UI.FindAction("In", throwIfNotFound: true);
        m_UI_Out = m_UI.FindAction("Out", throwIfNotFound: true);
        m_UI_Settings = m_UI.FindAction("Settings", throwIfNotFound: true);
        m_UI_Stop = m_UI.FindAction("Stop", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Press;
    private readonly InputAction m_Player_Cash;
    private readonly InputAction m_Player_LeftChange;
    private readonly InputAction m_Player_RightChange;
    private readonly InputAction m_Player_UP;
    private readonly InputAction m_Player_Down;
    private readonly InputAction m_Player_Throw;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Enter;
    public struct PlayerActions
    {
        private @InputPlayController m_Wrapper;
        public PlayerActions(@InputPlayController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Press => m_Wrapper.m_Player_Press;
        public InputAction @Cash => m_Wrapper.m_Player_Cash;
        public InputAction @LeftChange => m_Wrapper.m_Player_LeftChange;
        public InputAction @RightChange => m_Wrapper.m_Player_RightChange;
        public InputAction @UP => m_Wrapper.m_Player_UP;
        public InputAction @Down => m_Wrapper.m_Player_Down;
        public InputAction @Throw => m_Wrapper.m_Player_Throw;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Enter => m_Wrapper.m_Player_Enter;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Press.started += instance.OnPress;
            @Press.performed += instance.OnPress;
            @Press.canceled += instance.OnPress;
            @Cash.started += instance.OnCash;
            @Cash.performed += instance.OnCash;
            @Cash.canceled += instance.OnCash;
            @LeftChange.started += instance.OnLeftChange;
            @LeftChange.performed += instance.OnLeftChange;
            @LeftChange.canceled += instance.OnLeftChange;
            @RightChange.started += instance.OnRightChange;
            @RightChange.performed += instance.OnRightChange;
            @RightChange.canceled += instance.OnRightChange;
            @UP.started += instance.OnUP;
            @UP.performed += instance.OnUP;
            @UP.canceled += instance.OnUP;
            @Down.started += instance.OnDown;
            @Down.performed += instance.OnDown;
            @Down.canceled += instance.OnDown;
            @Throw.started += instance.OnThrow;
            @Throw.performed += instance.OnThrow;
            @Throw.canceled += instance.OnThrow;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Enter.started += instance.OnEnter;
            @Enter.performed += instance.OnEnter;
            @Enter.canceled += instance.OnEnter;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Press.started -= instance.OnPress;
            @Press.performed -= instance.OnPress;
            @Press.canceled -= instance.OnPress;
            @Cash.started -= instance.OnCash;
            @Cash.performed -= instance.OnCash;
            @Cash.canceled -= instance.OnCash;
            @LeftChange.started -= instance.OnLeftChange;
            @LeftChange.performed -= instance.OnLeftChange;
            @LeftChange.canceled -= instance.OnLeftChange;
            @RightChange.started -= instance.OnRightChange;
            @RightChange.performed -= instance.OnRightChange;
            @RightChange.canceled -= instance.OnRightChange;
            @UP.started -= instance.OnUP;
            @UP.performed -= instance.OnUP;
            @UP.canceled -= instance.OnUP;
            @Down.started -= instance.OnDown;
            @Down.performed -= instance.OnDown;
            @Down.canceled -= instance.OnDown;
            @Throw.started -= instance.OnThrow;
            @Throw.performed -= instance.OnThrow;
            @Throw.canceled -= instance.OnThrow;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Enter.started -= instance.OnEnter;
            @Enter.performed -= instance.OnEnter;
            @Enter.canceled -= instance.OnEnter;
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

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_In;
    private readonly InputAction m_UI_Out;
    private readonly InputAction m_UI_Settings;
    private readonly InputAction m_UI_Stop;
    public struct UIActions
    {
        private @InputPlayController m_Wrapper;
        public UIActions(@InputPlayController wrapper) { m_Wrapper = wrapper; }
        public InputAction @In => m_Wrapper.m_UI_In;
        public InputAction @Out => m_Wrapper.m_UI_Out;
        public InputAction @Settings => m_Wrapper.m_UI_Settings;
        public InputAction @Stop => m_Wrapper.m_UI_Stop;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @In.started += instance.OnIn;
            @In.performed += instance.OnIn;
            @In.canceled += instance.OnIn;
            @Out.started += instance.OnOut;
            @Out.performed += instance.OnOut;
            @Out.canceled += instance.OnOut;
            @Settings.started += instance.OnSettings;
            @Settings.performed += instance.OnSettings;
            @Settings.canceled += instance.OnSettings;
            @Stop.started += instance.OnStop;
            @Stop.performed += instance.OnStop;
            @Stop.canceled += instance.OnStop;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @In.started -= instance.OnIn;
            @In.performed -= instance.OnIn;
            @In.canceled -= instance.OnIn;
            @Out.started -= instance.OnOut;
            @Out.performed -= instance.OnOut;
            @Out.canceled -= instance.OnOut;
            @Settings.started -= instance.OnSettings;
            @Settings.performed -= instance.OnSettings;
            @Settings.canceled -= instance.OnSettings;
            @Stop.started -= instance.OnStop;
            @Stop.performed -= instance.OnStop;
            @Stop.canceled -= instance.OnStop;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPress(InputAction.CallbackContext context);
        void OnCash(InputAction.CallbackContext context);
        void OnLeftChange(InputAction.CallbackContext context);
        void OnRightChange(InputAction.CallbackContext context);
        void OnUP(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnIn(InputAction.CallbackContext context);
        void OnOut(InputAction.CallbackContext context);
        void OnSettings(InputAction.CallbackContext context);
        void OnStop(InputAction.CallbackContext context);
    }
}
