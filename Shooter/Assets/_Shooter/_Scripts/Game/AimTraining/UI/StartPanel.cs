using UnityEngine;
using UnityEngine.UI;
using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Data;
using GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces;
using TMPro;

namespace GlassyCode.Shooter.Game.AimTraining.UI
{
    public class StartPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _soldierLinesTmp;
        [SerializeField] private TextMeshProUGUI _agreeBtnTmp;
        [SerializeField] private Button _agreeBtn;

        private IAimTrainingManager _aimTrainingManager;
        
        [Inject]
        private void Construct(IAimTrainingManager aimTrainingManager)
        {
            _aimTrainingManager = aimTrainingManager;
        }

        private void OnEnable()
        {
            _soldierLinesTmp.text = AimTrainingConfig.FirstSergeantLine;
            _agreeBtnTmp.text = AimTrainingConfig.Agree;
            _agreeBtn.onClick.AddListener(SetSergeantSecondLine);
        }

        private void OnDisable()
        {
            _agreeBtn.onClick.RemoveAllListeners();
        }

        private void SetSergeantSecondLine()
        {
            _agreeBtn.onClick.RemoveListener(SetSergeantSecondLine);
            _soldierLinesTmp.text = AimTrainingConfig.SecondSergeantLine;
            _agreeBtn.onClick.AddListener(StartRound);
        }
        
        private void SetTryAgain()
        {
            _soldierLinesTmp.text = AimTrainingConfig.SecondSergeantLine;
        }

        private void StartRound()
        {
            _aimTrainingManager.StartPreparation();
            Hide();
        }
    }
}