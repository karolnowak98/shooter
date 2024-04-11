using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Logic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GlassyCode.Shooter.Game.AimTraining.UI
{
    public class ModeSelectionPanel : Panel
    {
        [SerializeField] private Button _button;

        private IAimTrainingController _aimTrainingController;
        
        [Inject]
        private void Construct(IAimTrainingController aimTrainingController)
        {
            _aimTrainingController = aimTrainingController;
            
            _button.onClick.AddListener(_aimTrainingController.StartRound);
            _button.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}