using System;
using GlassyCode.Shooter.Core.Scenes;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimMap.Data;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.AimMap.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GlassyCode.Shooter.Game.AimMap.UI
{
    public class AimMapDialoguePanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _sergeantLinesTmp;
        [SerializeField] private TextMeshProUGUI _agreeBtnTmp;
        [SerializeField] private TextMeshProUGUI _missionObjectiveTmp;
        [SerializeField] private GameObject _missionObjectiveObj;
        [SerializeField] private Button _agreeBtn;

        private IScenesController _scenesController;
        private IAimMapManager _aimMapManager;
        private IAimMapConfig _config;
        
        [Inject]
        private void Construct(IScenesController scenesController, IAimMapManager aimMapManager, IAimMapConfig config)
        {
            _scenesController = scenesController;
            _aimMapManager = aimMapManager;
            _config = config;

            _aimMapManager.OnRoundFinished += SetPanel;
        }

        private void OnDestroy()
        {
            _aimMapManager.OnRoundFinished -= SetPanel;
        }

        private void Awake()
        {
            _sergeantLinesTmp.text = AimMapDialogues.FirstSergeantLine;
            _agreeBtnTmp.text = AimMapDialogues.Surprised;
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

        private void SetSergeantFirstLine()
        {
            
        }

        private void SetSergeantSecondLine()
        {
            var configSuccessConditionsData = _config.SuccessConditionsDataData;
            
            _sergeantLinesTmp.text = AimMapDialogues.SecondSergeantLine;
            _missionObjectiveTmp.text = $" Mission objective: {configSuccessConditionsData.HitsConditionData.Counter} hits with {configSuccessConditionsData.AccuracyConditionData.Percentage}% accuracy";
            _agreeBtnTmp.text = AimMapDialogues.StartRound;
            _missionObjectiveObj.SetActive(true);
            _agreeBtn.onClick.RemoveAllListeners();
            _agreeBtn.onClick.AddListener(StartRound);
        }
        
        private void SetFailurePanel()
        {
            _sergeantLinesTmp.text = AimMapDialogues.TryAgainSergeantLine;
            _agreeBtnTmp.text = AimMapDialogues.RestartRound;
            _agreeBtn.onClick.RemoveAllListeners();
            _agreeBtn.onClick.AddListener(StartRound);
            Show();
        }
        
        private void SetSuccessPanel()
        {
            _missionObjectiveObj.SetActive(false);
            _sergeantLinesTmp.text = AimMapDialogues.SuccessSergeantLine;
            _agreeBtnTmp.text = AimMapDialogues.GoToBattlefield;
            _agreeBtn.onClick.RemoveAllListeners();
            _agreeBtn.onClick.AddListener(GoToNextMap);
            Show();
        }

        private void StartRound()
        {
            _aimMapManager.RestartRound();
            Hide();
        }

        private void GoToNextMap()
        {
            _scenesController.LoadDustMapScene();
        }
    }
}