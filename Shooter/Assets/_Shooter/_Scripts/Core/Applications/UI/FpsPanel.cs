using UnityEngine;
using TMPro;
using GlassyCode.Shooter.Core.UI;

namespace GlassyCode.Shooter.Core.Applications.UI
{
    public class FpsPanel : Panel
    {
        [SerializeField, Tooltip("In seconds.")] 
        private int _fpsUpdateRate;
        
        [SerializeField] 
        private TextMeshProUGUI _fpsTmp;

        private float _frameCount;
        private float _fps;
        private float _time;
        
        private void Update()
        {
            _time += UnityEngine.Time.deltaTime;
            _frameCount++;
            
            if (_time >= _fpsUpdateRate)
            {
                _fps = Mathf.RoundToInt(_frameCount / _time);
                _fpsTmp.text = $"{_fps} FPS";

                _time -= _fpsUpdateRate;
                _frameCount = 0;
            }
        }
    }
}