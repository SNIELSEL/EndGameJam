//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/JetskiInputActions.inputactions
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

public partial class @JetskiInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @JetskiInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""JetskiInputActions"",
    ""maps"": [
        {
            ""name"": ""JetskiMap"",
            ""id"": ""07008b54-4489-422e-9c2a-a02f07e59f14"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""eb96425a-ea99-4f16-8e9a-276c6f97c1b9"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a9a42205-fc83-49d1-a05f-fc8610eff8be"",
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
                    ""id"": ""c3141da2-be56-461c-b958-aba77da0ec2c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""05f56f94-e272-4828-9722-d967e9fb56d6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5e540f48-2efe-4347-87ce-9646e4e8a15f"",
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
                    ""id"": ""031d0b7b-3118-4478-bfc4-26413c280028"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // JetskiMap
        m_JetskiMap = asset.FindActionMap("JetskiMap", throwIfNotFound: true);
        m_JetskiMap_Move = m_JetskiMap.FindAction("Move", throwIfNotFound: true);
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

    // JetskiMap
    private readonly InputActionMap m_JetskiMap;
    private List<IJetskiMapActions> m_JetskiMapActionsCallbackInterfaces = new List<IJetskiMapActions>();
    private readonly InputAction m_JetskiMap_Move;
    public struct JetskiMapActions
    {
        private @JetskiInputActions m_Wrapper;
        public JetskiMapActions(@JetskiInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_JetskiMap_Move;
        public InputActionMap Get() { return m_Wrapper.m_JetskiMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JetskiMapActions set) { return set.Get(); }
        public void AddCallbacks(IJetskiMapActions instance)
        {
            if (instance == null || m_Wrapper.m_JetskiMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_JetskiMapActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IJetskiMapActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IJetskiMapActions instance)
        {
            if (m_Wrapper.m_JetskiMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IJetskiMapActions instance)
        {
            foreach (var item in m_Wrapper.m_JetskiMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_JetskiMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public JetskiMapActions @JetskiMap => new JetskiMapActions(this);
    public interface IJetskiMapActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
