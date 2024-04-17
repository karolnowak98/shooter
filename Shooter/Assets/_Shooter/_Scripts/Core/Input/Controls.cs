//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Shooter/Data/Input/Controls.inputactions
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

namespace GlassyCode.Shooter.Game.Input.Logic
{
    public partial class @Controls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""84e05603-bc9b-40b5-8fe1-6b79d92211eb"",
            ""actions"": [
                {
                    ""name"": ""Lmb"",
                    ""type"": ""Button"",
                    ""id"": ""5c1aca8d-a666-43e3-9959-7d5d0e0f0ac7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4c52c5c0-3827-4ad3-99fc-002f07248580"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Btn1"",
                    ""type"": ""Button"",
                    ""id"": ""52244465-ddaf-4bcd-943d-fb67679cb1e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Btn2"",
                    ""type"": ""Button"",
                    ""id"": ""7fc04732-d483-423b-bced-1494283a72d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Btn3"",
                    ""type"": ""Button"",
                    ""id"": ""664163eb-88b8-44c9-af91-252b1692134f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""f6034451-b82c-4dcd-9492-377f0aa96627"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""R"",
                    ""type"": ""Button"",
                    ""id"": ""4b7ea6a2-fe39-4b44-b213-e64c7edcafd5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""6c9e7f6b-7f64-4555-808e-66013cc95f79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P"",
                    ""type"": ""Button"",
                    ""id"": ""ca4dbef3-156a-4a6f-aff2-7351e3dce067"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""edbc1669-e651-49d2-a7da-f5ee49312cad"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lmb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""6afba732-4526-4c08-9e4a-ef48001b3176"",
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
                    ""id"": ""a2574154-073c-47fb-a1d5-41d6c779e9db"",
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
                    ""id"": ""c0e9219f-c295-415d-be72-7d599bb12c18"",
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
                    ""id"": ""a7ba732e-599d-4f4e-a56a-597943bd0410"",
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
                    ""id"": ""78244853-69ca-4b2d-9ec4-ecdb2b3982ed"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""d0666d0a-cfd2-41e1-8bf3-1092d86f49f0"",
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
                    ""id"": ""1adce4ec-46eb-4c46-a97f-3e1796c06d26"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ecc8a0f8-6307-4adb-8bd8-c90c6cb357d2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""34dec466-6ce5-44b4-b3de-936c46dd0d9f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8199260a-f7d3-4b4e-935d-ec41e001b071"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1bdb87a9-a0ef-4c72-9104-264454a3ace4"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Btn1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dd9a68e-8052-4043-84dd-d5d03eac241f"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Btn2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4e03b6b-07ed-4a17-ab57-7d3d4a0ff92a"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Btn3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c46d5118-39c4-46f6-8b97-66b8a84f0070"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e7d0346-9470-4500-b9ab-0737feba789a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""892ca0e2-adb8-483d-b431-341607b23c16"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6de2eb79-b2a1-4adc-866a-82b08140e35b"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_Lmb = m_Gameplay.FindAction("Lmb", throwIfNotFound: true);
            m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
            m_Gameplay_Btn1 = m_Gameplay.FindAction("Btn1", throwIfNotFound: true);
            m_Gameplay_Btn2 = m_Gameplay.FindAction("Btn2", throwIfNotFound: true);
            m_Gameplay_Btn3 = m_Gameplay.FindAction("Btn3", throwIfNotFound: true);
            m_Gameplay_Scroll = m_Gameplay.FindAction("Scroll", throwIfNotFound: true);
            m_Gameplay_R = m_Gameplay.FindAction("R", throwIfNotFound: true);
            m_Gameplay_Space = m_Gameplay.FindAction("Space", throwIfNotFound: true);
            m_Gameplay_P = m_Gameplay.FindAction("P", throwIfNotFound: true);
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

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
        private readonly InputAction m_Gameplay_Lmb;
        private readonly InputAction m_Gameplay_Move;
        private readonly InputAction m_Gameplay_Btn1;
        private readonly InputAction m_Gameplay_Btn2;
        private readonly InputAction m_Gameplay_Btn3;
        private readonly InputAction m_Gameplay_Scroll;
        private readonly InputAction m_Gameplay_R;
        private readonly InputAction m_Gameplay_Space;
        private readonly InputAction m_Gameplay_P;
        public struct GameplayActions
        {
            private @Controls m_Wrapper;
            public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Lmb => m_Wrapper.m_Gameplay_Lmb;
            public InputAction @Move => m_Wrapper.m_Gameplay_Move;
            public InputAction @Btn1 => m_Wrapper.m_Gameplay_Btn1;
            public InputAction @Btn2 => m_Wrapper.m_Gameplay_Btn2;
            public InputAction @Btn3 => m_Wrapper.m_Gameplay_Btn3;
            public InputAction @Scroll => m_Wrapper.m_Gameplay_Scroll;
            public InputAction @R => m_Wrapper.m_Gameplay_R;
            public InputAction @Space => m_Wrapper.m_Gameplay_Space;
            public InputAction @P => m_Wrapper.m_Gameplay_P;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void AddCallbacks(IGameplayActions instance)
            {
                if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
                @Lmb.started += instance.OnLmb;
                @Lmb.performed += instance.OnLmb;
                @Lmb.canceled += instance.OnLmb;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Btn1.started += instance.OnBtn1;
                @Btn1.performed += instance.OnBtn1;
                @Btn1.canceled += instance.OnBtn1;
                @Btn2.started += instance.OnBtn2;
                @Btn2.performed += instance.OnBtn2;
                @Btn2.canceled += instance.OnBtn2;
                @Btn3.started += instance.OnBtn3;
                @Btn3.performed += instance.OnBtn3;
                @Btn3.canceled += instance.OnBtn3;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
                @R.started += instance.OnR;
                @R.performed += instance.OnR;
                @R.canceled += instance.OnR;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
                @P.started += instance.OnP;
                @P.performed += instance.OnP;
                @P.canceled += instance.OnP;
            }

            private void UnregisterCallbacks(IGameplayActions instance)
            {
                @Lmb.started -= instance.OnLmb;
                @Lmb.performed -= instance.OnLmb;
                @Lmb.canceled -= instance.OnLmb;
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Btn1.started -= instance.OnBtn1;
                @Btn1.performed -= instance.OnBtn1;
                @Btn1.canceled -= instance.OnBtn1;
                @Btn2.started -= instance.OnBtn2;
                @Btn2.performed -= instance.OnBtn2;
                @Btn2.canceled -= instance.OnBtn2;
                @Btn3.started -= instance.OnBtn3;
                @Btn3.performed -= instance.OnBtn3;
                @Btn3.canceled -= instance.OnBtn3;
                @Scroll.started -= instance.OnScroll;
                @Scroll.performed -= instance.OnScroll;
                @Scroll.canceled -= instance.OnScroll;
                @R.started -= instance.OnR;
                @R.performed -= instance.OnR;
                @R.canceled -= instance.OnR;
                @Space.started -= instance.OnSpace;
                @Space.performed -= instance.OnSpace;
                @Space.canceled -= instance.OnSpace;
                @P.started -= instance.OnP;
                @P.performed -= instance.OnP;
                @P.canceled -= instance.OnP;
            }

            public void RemoveCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGameplayActions instance)
            {
                foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);
        public interface IGameplayActions
        {
            void OnLmb(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnBtn1(InputAction.CallbackContext context);
            void OnBtn2(InputAction.CallbackContext context);
            void OnBtn3(InputAction.CallbackContext context);
            void OnScroll(InputAction.CallbackContext context);
            void OnR(InputAction.CallbackContext context);
            void OnSpace(InputAction.CallbackContext context);
            void OnP(InputAction.CallbackContext context);
        }
    }
}
