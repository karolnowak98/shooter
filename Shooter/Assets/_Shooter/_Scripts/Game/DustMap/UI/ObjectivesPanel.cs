using System;
using UnityEngine;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.DustMap.Data;
using GlassyCode.Shooter.Game.DustMap.Logic;
using GlassyCode.Shooter.Game.Props.Enums;

namespace GlassyCode.Shooter.Game.DustMap.UI
{
    public class ObjectivesPanel : Panel, IDisposable
    {
        [SerializeField] private TextMeshProUGUI _chestsTmp;
        [SerializeField] private TextMeshProUGUI _jugsTmp;
        [SerializeField] private TextMeshProUGUI _barrelsTmp;
        [SerializeField] private TextMeshProUGUI _bottlesTmp;
        [SerializeField] private TextMeshProUGUI _axesTmp;

        private IDustMapManager _dustMapManager;
        private SuccessConditionsData _conditions;
        
        [Inject]
        private void Construct(IDustMapConfig dustMapConfig, IDustMapManager dustMapManager)
        {
            _conditions = dustMapConfig.SuccessConditionsData;
            _dustMapManager = dustMapManager;
            
            _dustMapManager.OnPropDestroyed += IncrementPropValue;
            _dustMapManager.OnMissionStarted += ResetPanel;
            _dustMapManager.OnMissionFinished += Hide;
        }
        
        public void Dispose()
        {
            _dustMapManager.OnPropDestroyed -= IncrementPropValue;
            _dustMapManager.OnMissionStarted -= ResetPanel;
            _dustMapManager.OnMissionFinished -= Hide;
        }

        private void Hide(RoundResult obj)
        {
            Hide();
        }

        private void ResetPanel()
        {
            _chestsTmp.text = $"Boxes: 0/{_conditions.Boxes.Counter}";
            _jugsTmp.text = $"Jugs: 0/{_conditions.Jugs.Counter}";
            _barrelsTmp.text = $"Barrels: 0/{_conditions.Barrels.Counter}";
            _bottlesTmp.text = $"Bottles: 0/{_conditions.Bottles.Counter}";
            _axesTmp.text = $"Axes: 0/{_conditions.Axes.Counter}";
            
            Show();
        }

        private void IncrementPropValue(PropName propName, uint destroyedNumber)
        {
            switch (propName)
            {
                case PropName.Box:
                    _chestsTmp.text = $"Boxes: {destroyedNumber}/{_conditions.Boxes.Counter}";
                    break;
                case PropName.Jug:
                    _jugsTmp.text = $"Jugs: {destroyedNumber}/{_conditions.Jugs.Counter}";
                    break;
                case PropName.Barrel:
                    _barrelsTmp.text = $"Barrels: {destroyedNumber}/{_conditions.Barrels.Counter}";
                    break;
                case PropName.Bottle:
                    _bottlesTmp.text = $"Bottles: {destroyedNumber}/{_conditions.Bottles.Counter}";
                    break;
                case PropName.Axe:
                    _axesTmp.text = $"Axes: {destroyedNumber}/{_conditions.Axes.Counter}";
                    break;
                case PropName.Target:
                case PropName.Stone:
                case PropName.Plate:
                default:
                    throw new ArgumentOutOfRangeException(nameof(propName), propName, null);
            }
        }
    }
}