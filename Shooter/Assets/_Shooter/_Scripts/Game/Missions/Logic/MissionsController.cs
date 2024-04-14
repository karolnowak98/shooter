using System.Collections.Generic;
using Zenject;

namespace GlassyCode.Shooter.Game.Missions.Logic
{
    public class MissionsController : IMissionsController
    {
        private Stack<IMission> _missions;

        [Inject]
        private void Construct()
        {
            
        }
    }
}