using GlassyCode.Shooter.Core.Time;
using GlassyCode.Shooter.Game.Player.Logic;

namespace GlassyCode.Shooter.Game.AimTraining.Logic
{
    public sealed class RoundTimer : Timer
    {
        private readonly ICameraController _cameraController;
        
        public RoundTimer(ICameraController cameraController, ITimeController timeController, float countdownTime, float refreshUIInterval) 
            : base(timeController, countdownTime, refreshUIInterval)
        {
            _cameraController = cameraController;
        }
        
        public override void Reset()
        {
            base.Reset();
            _cameraController.UnlockCamera();
        }
    }
}