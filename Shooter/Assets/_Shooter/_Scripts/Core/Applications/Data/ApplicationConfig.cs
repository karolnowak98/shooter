using GlassyCode.Shooter.Core.Data;
using UnityEngine;

namespace GlassyCode.Shooter.Core.Applications.Data
{
    [CreateAssetMenu(menuName = "Configs/Application Config", fileName = "Application Config")]
    public class ApplicationConfig : Config
    {
        [SerializeField] private int _targetFps;

        public int TargetFps => _targetFps;
    }
}