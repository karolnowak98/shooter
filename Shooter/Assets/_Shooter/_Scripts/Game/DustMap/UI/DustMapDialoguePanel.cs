using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.Applications.Logic;
using GlassyCode.Shooter.Core.Scenes;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.DustMap.Data;
using GlassyCode.Shooter.Game.DustMap.Logic;

namespace GlassyCode.Shooter.Game.DustMap.UI
{
    public class DustMapDialoguePanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _sergeantLinesTmp;
        [SerializeField] private TextMeshProUGUI _playerLinesTmp;
        [SerializeField] private Button _playerLinesBtn;

        private IApplicationController _applicationController;
        private IScenesController _scenesController;
        private IDustMapManager _dustMapManager;
        private IDustMapDialogue _dialogue;
        
        [Inject]
        private void Construct(IScenesController scenesController, IApplicationController applicationController, IDustMapManager dustMapManager)
        {
            _scenesController = scenesController;
            _applicationController = applicationController;
            _dustMapManager = dustMapManager;

            _dustMapManager.OnMissionFinished += SetFinishPanel;
        }
        
        private void OnDestroy()
        {
            _dustMapManager.OnMissionFinished -= SetFinishPanel;
            _playerLinesBtn.onClick.RemoveAllListeners();
        }

        private void Awake()
        {
            InitDialogue();
        }

        private void InitDialogue()
        {
            _playerLinesBtn.onClick.AddListener(SetNextLine);
            
            var successLine = new DialogueLine
            {
                CharacterLine = DustMapDialogues.SuccessSergeantLine, PlayerLine = DustMapDialogues.SuccessPlayerLine
            };
            
            var failureLine = new DialogueLine
            {
                CharacterLine = DustMapDialogues.FailureSergeantLine, PlayerLine = DustMapDialogues.FailurePlayerLine
            };
            
            _dialogue = new DustMapDialogue(successLine, failureLine);
            
            _dialogue.EnqueueLine(DustMapDialogues.FirstSergeantLine, DustMapDialogues.FirstPlayerLine);
            _dialogue.EnqueueLine(DustMapDialogues.SecondSergeantLine, DustMapDialogues.SecondPlayerLine);
            _dialogue.EnqueueLine(DustMapDialogues.ThirdSergeantLine, DustMapDialogues.ThirdPlayerLine);
            _dialogue.EnqueueLine(DustMapDialogues.FourthSergeantLine, DustMapDialogues.FourthPlayerLine);
            _dialogue.EnqueueLine(DustMapDialogues.FifthSergeantLine, DustMapDialogues.FifthPlayerLine);
            
            SetNextLine();
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
        
        private void SetSuccessPanel()
        {
            SetPanel(_dialogue.SuccessLine);
            
            _playerLinesBtn.onClick.RemoveAllListeners();
            _playerLinesBtn.onClick.AddListener(() => _applicationController.QuitApplication());
            Show();
        }
        
        private void SetFailurePanel()
        {
            SetPanel(_dialogue.FailureLine);
            
            _playerLinesBtn.onClick.RemoveAllListeners();
            _playerLinesBtn.onClick.AddListener(() => _scenesController.LoadAimMapScene());
            Show();
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
                _playerLinesBtn.onClick.RemoveAllListeners();
                StartMission();
            }
        }
        
        private void SetPanel(DialogueLine line)
        {
            _sergeantLinesTmp.text = line.CharacterLine;
            _playerLinesTmp.text = line.PlayerLine;
        }

        private void StartMission()
        {
            _dustMapManager.RestartRound();
            Hide();
        }
    }
}