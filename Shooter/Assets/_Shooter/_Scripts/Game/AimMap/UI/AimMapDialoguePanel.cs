using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.Scenes;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Core.UI.Logic;
using GlassyCode.Shooter.Game.AimMap.Data;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.AimMap.Logic;

namespace GlassyCode.Shooter.Game.AimMap.UI
{
    public class AimMapDialoguePanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _sergeantLinesTmp;
        [SerializeField] private TextMeshProUGUI _playerLineTmp;
        [SerializeField] private TextMeshProUGUI _missionObjectiveTmp;
        [SerializeField] private GameObject _missionObjectiveObj;
        [SerializeField] private Button _playerLinesBtn;

        private IScenesController _scenesController;
        private IAimMapManager _aimMapManager;
        private IAimMapConfig _config;
        private IAimMapDialogue _dialogue;
        
        [Inject]
        private void Construct(IScenesController scenesController, IAimMapManager aimMapManager, IAimMapConfig config)
        {
            _scenesController = scenesController;
            _aimMapManager = aimMapManager;
            _config = config;

            _aimMapManager.OnRoundFinished += SetFinishPanel;
        }

        private void OnDestroy()
        {
            _aimMapManager.OnRoundFinished -= SetFinishPanel;
            _playerLinesBtn.onClick.RemoveAllListeners();
        }

        private void Awake()
        {
            InitDialogue();
        }

        private void InitDialogue()
        {
            var successLine = new DialogueLine
            {
                CharacterLine = AimMapDialogues.SuccessSergeantLine, PlayerLine = AimMapDialogues.SuccessPlayerLine
            };
            
            var failureLine = new DialogueLine
            {
                CharacterLine = AimMapDialogues.FailureSergeantLine, PlayerLine = AimMapDialogues.FailurePlayerLine
            };

            _dialogue = new AimMapDialogue(successLine, failureLine);
            
            _dialogue.EnqueueLine(AimMapDialogues.FirstSergeantLine, AimMapDialogues.FirstPlayerLine);
            _dialogue.EnqueueLine(AimMapDialogues.SecondSergeantLine, AimMapDialogues.SecondPlayerLine);

            SetNextLine();
            _playerLinesBtn.onClick.AddListener(SetNextLine);
        }
        
        private void SetNextLine()
        {
            var nextLine = _dialogue.GetNextLine();

            if (nextLine.HasValue)
            {
                SetPanel(nextLine.Value);
            }
            else
            {
                var configSuccessConditionsData = _config.SuccessConditionsDataData;
                _missionObjectiveTmp.text = $" Mission objective: {configSuccessConditionsData.HitsConditionData.Counter} hits with {configSuccessConditionsData.AccuracyConditionData.Percentage}% accuracy";
                _missionObjectiveObj.SetActive(true);
                _playerLinesBtn.onClick.RemoveAllListeners();
                _playerLinesBtn.onClick.AddListener(StartRound);
                _playerLinesBtn.onClick.RemoveAllListeners();
                StartRound();
            }
        }

        private void SetPanel(DialogueLine line)
        {
            _sergeantLinesTmp.text = line.CharacterLine;
            _playerLineTmp.text = line.PlayerLine;
        }

        private void SetFinishPanel(RoundResult roundResult)
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
        
        private void SetFailurePanel()
        {
            SetPanel(_dialogue.FailureLine);
            
            _playerLinesBtn.onClick.RemoveAllListeners();
            _playerLinesBtn.onClick.AddListener(StartRound);
            Show();
        }
        
        private void SetSuccessPanel()
        {
            SetPanel(_dialogue.SuccessLine);
            
            _missionObjectiveObj.SetActive(false);
            _playerLinesBtn.onClick.RemoveAllListeners();
            _playerLinesBtn.onClick.AddListener(()=>_scenesController.LoadDustMapScene());
            Show();
        }

        private void StartRound()
        {
            _aimMapManager.RestartRound();
            Hide();
        }
    }
}