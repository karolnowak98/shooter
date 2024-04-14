using System;
using UnityEngine;

namespace GlassyCode.Shooter.Core.Time
{
    public class TimeController : MonoBehaviour, ITimeController
    {
        public float DeltaTime => UnityEngine.Time.deltaTime;
        public float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime; 
        public float UnscaledDeltaTime => UnityEngine.Time.unscaledDeltaTime;
        
        public float RegularTime => UnityEngine.Time.time;
        public float FixedTime => UnityEngine.Time.fixedTime;
        public float UnscaledTime => UnityEngine.Time.unscaledTime;

        public static event Action OnPaused;
        public static event Action OnResumed;
        public static bool IsPaused { get; private set; }
        
        public static void Pause()
        {
            if (UnityEngine.Time.timeScale <= 0) return;
            
            UnityEngine.Time.timeScale = 0;
            IsPaused = true;
            OnPaused?.Invoke();
        }

        public static void Resume()
        {
            if (UnityEngine.Time.timeScale != 0) return;
            
            UnityEngine.Time.timeScale = 1;
            IsPaused = false;
            OnResumed?.Invoke();
        }

        public static void TogglePause()
        {
            if (UnityEngine.Time.timeScale > 0)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
}