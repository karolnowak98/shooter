using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Logic;
using GlassyCode.Shooter.Game.Props.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.AimTraining.UI
{
    public class InfoPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _timeLeftTmp;
        [SerializeField] private TextMeshProUGUI _hitsTmp;
        [SerializeField] private TextMeshProUGUI _missesTmp;
        
        private IAimTrainingController _aimTrainingController;
        private IShootingController _shootingController;

        private int _hits;
        private int _misses;
        
        [Inject]
        private void Construct(IAimTrainingController aimTrainingController, IShootingController shootingController)
        {
            _aimTrainingController = aimTrainingController;
            _shootingController = shootingController;
            
            _aimTrainingController.OnUpdateTimer += SetTimeLeftTmp;
            _aimTrainingController.OnRoundStarted += ResetPanel;
            _shootingController.OnShoot += CalculateHitsMisses;
        }

        private void OnDestroy()
        {
            _aimTrainingController.OnUpdateTimer -= SetTimeLeftTmp;
            _aimTrainingController.OnRoundStarted -= ResetPanel;
            _shootingController.OnShoot -= CalculateHitsMisses;
        }

        private void ResetPanel()
        {
            _hits = 0;
            _misses = 0;
            _hitsTmp.text = _hits.ToString();
            _missesTmp.text = _misses.ToString();
            _timeLeftTmp.text = "";
            Show();
        }

        private void SetTimeLeftTmp(float seconds)
        {
            _timeLeftTmp.text = seconds.ToString("0.00");
        }

        private void CalculateHitsMisses(IDestroyable hitObject)
        {
            if (hitObject is null)
            {
                _misses++;
                _missesTmp.text = _misses.ToString();
            }
            else
            {
                _hits++;
                _hitsTmp.text = _hits.ToString();
            }
        }
    }
}