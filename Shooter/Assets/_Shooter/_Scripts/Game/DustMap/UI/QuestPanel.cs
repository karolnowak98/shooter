using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Logic;
using GlassyCode.Shooter.Game.AimTraining.Logic.Targets;
using TMPro;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.DustMap.UI
{
    public class QuestPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _hitsConditionTmp;
        [SerializeField] private TextMeshProUGUI _percentageConditionTmp;

        private ITargetsController _targetsController;
        
        [Inject]
        private void Construct(IAimTrainingManager trainingManager)
        {
            _targetsController = trainingManager.TargetsController;
        }
    }
}