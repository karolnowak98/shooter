using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Data;
using GlassyCode.Shooter.Game.AimTraining.Enums;
using GlassyCode.Shooter.Game.AimTraining.Logic;

namespace GlassyCode.Shooter.Game.AimTraining.UI
{
    public class DialoguePanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _sergeantLinesTmp;
        [SerializeField] private TextMeshProUGUI _agreeBtnTmp;
        [SerializeField] private TextMeshProUGUI _missionObjectiveTmp;
        [SerializeField] private GameObject _missionObjectiveObj;
        [SerializeField] private Button _agreeBtn;

        private IAimTrainingManager _aimTrainingManager;
        private IAimTrainingConfig _config;
        
        [Inject]
        private void Construct(IAimTrainingManager aimTrainingManager, IAimTrainingConfig config)
        {
            _aimTrainingManager = aimTrainingManager;
            _config = config;

            _aimTrainingManager.OnRoundFinished += SetPanel;
        }

        private void OnDestroy()
        {
            _aimTrainingManager.OnRoundFinished -= SetPanel;
        }

        private void Awake()
        {
            _sergeantLinesTmp.text = AimTrainingDialogues.FirstSergeantLine;
            _agreeBtnTmp.text = AimTrainingDialogues.Surprised;
        }

        private void OnEnable()
        {
            _agreeBtn.onClick.AddListener(SetSergeantSecondLine);
        }

        private void OnDisable()
        {
            _agreeBtn.onClick.RemoveAllListeners();
        }

        private void SetPanel(RoundResult roundResult)
        {
            switch (roundResult)
            {
                case RoundResult.Success:
                    SetSuccessPanel();
                    break;
                case RoundResult.Failure:
                    SetFailurePanel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(roundResult), roundResult, null);
            }
        }

        private void SetSergeantSecondLine()
        {
            var configSuccessConditionsData = _config.SuccessConditionsDataData;
            
            _sergeantLinesTmp.text = AimTrainingDialogues.SecondSergeantLine;
            _missionObjectiveTmp.text = $" Mission objective: {configSuccessConditionsData.HitsConditionData.Counter} hits with {configSuccessConditionsData.AccuracyConditionData.Percentage}% accuracy";
            _agreeBtnTmp.text = AimTrainingDialogues.StartRound;
            _missionObjectiveObj.SetActive(true);
            _agreeBtn.onClick.RemoveAllListeners();
            _agreeBtn.onClick.AddListener(StartRound);
        }
        
        private void SetFailurePanel()
        {
            _sergeantLinesTmp.text = AimTrainingDialogues.TryAgainSergeantLine;
            _agreeBtnTmp.text = AimTrainingDialogues.RestartRound;
            _agreeBtn.onClick.RemoveAllListeners();
            _agreeBtn.onClick.AddListener(StartRound);
            Show();
        }
        
        private void SetSuccessPanel()
        {
            _missionObjectiveObj.SetActive(false);
            _sergeantLinesTmp.text = AimTrainingDialogues.SuccessSergeantLine;
            _agreeBtnTmp.text = AimTrainingDialogues.GoToBattlefield;
            _agreeBtn.onClick.RemoveAllListeners();
            _agreeBtn.onClick.AddListener(GoToNextMap);
            Show();
        }

        private void StartRound()
        {
            _aimTrainingManager.RestartRound();
            Hide();
        }

        private void GoToNextMap()
        {
            Debug.Log("Success");
        }
    }
}