using UnityEngine;
using GlassyCode.Shooter.Core.Data;

namespace GlassyCode.Shooter.Core.Applications.Data
{
    [CreateAssetMenu(menuName = "Configs/Application Config", fileName = "Application Config")]
    public class ApplicationConfig : Config, IApplicationConfig
    {
        [SerializeField] private int _targetFps;

        public int TargetFps => _targetFps;
    }
}