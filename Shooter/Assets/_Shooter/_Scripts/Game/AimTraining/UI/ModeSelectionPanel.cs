using UnityEngine;
using UnityEngine.UI;
using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces;

namespace GlassyCode.Shooter.Game.AimTraining.UI
{
    public class ModeSelectionPanel : Panel
    {
        [SerializeField] private Button _button;

        private IAimTrainingManager _aimTrainingManager;
        
        [Inject]
        private void Construct(IAimTrainingManager aimTrainingManager)
        {
            _aimTrainingManager = aimTrainingManager;
            
            _button.onClick.AddListener(StartRound);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void StartRound()
        {
            _aimTrainingManager.StartPreparation();
            Hide();
        }
    }
}