using GlassyCode.Shooter.Core.Applications.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Core.Applications.Logic
{
    public class ApplicationController : IApplicationController, IInitializable
    {
        private IApplicationConfig _applicationConfig;

        [Inject]
        private void Construct(IApplicationConfig applicationConfig)
        {
            _applicationConfig = applicationConfig;
        }
        
        public void Initialize()
        {
            Application.targetFrameRate = _applicationConfig.TargetFps;
        }
    }
}