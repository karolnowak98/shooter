using GlassyCode.Shooter.Core.Data;
using UnityEngine;

namespace GlassyCode.Shooter.Game.AimTraining.Data
{
    [CreateAssetMenu(menuName = "Configs/Aim Training Config", fileName = "Aim Training Config")]
    public class AimTrainingConfig : Config, IAimTrainingConfig
    {
        //Might be better to use I2Loc for example
        public const string FirstSergeantLine = "Welcome to the training, soldier. Your first mission is to hone your shooting skills. I'm your superior officer, and I'll be guiding you through this.";
        public const string SecondSergeantLine = "You'll be firing at targets against the clock. Remember, precision and speed are paramount. Ready to prove your mettle, soldier?";
        public const string SuccessSergeantLine = "Good job my friend!";
        public const string TryAgainSergeantLine = "Keep going, you are better!";
        
        public const string Agree = "Okay...";
        public const string StartRound = "Keep going, you are better!";
        public const string SuccessBtnText = "Good job my friend!";
        
        [SerializeField] private TimerData _preparationTimer;
        [SerializeField] private TimerData _roundTimer;

        public TimerData PreparationTimer => _preparationTimer;
        public TimerData RoundTimer => _roundTimer;
    }
}