using GlassyCode.Shooter.Core.Applications.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Core.Applications.Logic
{
    public class ApplicationController : IApplicationController, IInitializable
    {
        private ApplicationConfig _applicationConfig;

        [Inject]
        private void Construct(ApplicationConfig applicationConfig)
        {
            _applicationConfig = applicationConfig;
        }
        
        public void Initialize()
        {
            Application.targetFrameRate = _applicationConfig.TargetFps;
        }
    }
}