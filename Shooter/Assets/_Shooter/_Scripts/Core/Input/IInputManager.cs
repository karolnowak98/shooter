using System;
using UnityEngine;

namespace GlassyCode.Shooter.Core.Input
{
    public interface IInputManager
    {
        Vector2 MoveAxis { get; }
        event Action OnLmbPerformed;
        event Action OnLmbCanceled;
        event Action OnBtn1Pressed;
        event Action OnBtn2Pressed;
        event Action OnBtn3Pressed;
        event Action OnRPressed;
        event Action OnPPressed;
        event Action OnSpacePressed;
        event Action OnScrollUp;
        event Action OnScrollDown;
    }
}