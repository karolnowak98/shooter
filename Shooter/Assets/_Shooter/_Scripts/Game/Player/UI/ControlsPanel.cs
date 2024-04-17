using System;
using UnityEngine;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.Input;
using GlassyCode.Shooter.Core.UI;

namespace GlassyCode.Shooter.Game.Player.UI
{
    public class ControlsPanel : Panel, IDisposable
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _clickPToShowPanelTmp;
        [SerializeField] private TextMeshProUGUI _moveTmp;
        [SerializeField] private TextMeshProUGUI _jumpTmp;
        [SerializeField] private TextMeshProUGUI _shootTmp;
        [SerializeField] private TextMeshProUGUI _reloadTmp;
        [SerializeField] private TextMeshProUGUI _changeWeapon;

        private InputManager _inputManager;

        [Inject]
        private void Construct(InputManager inputManager)
        {
            _inputManager = inputManager;
            
            _inputManager.OnPPressed += TogglePanel;
        }
        
        public void Dispose()
        {
            _inputManager.OnPPressed -= TogglePanel;
        }

        private void Start()
        {
            UpdateControlsPanel();
        }
        
        private void TogglePanel()
        {
            ToggleVisibility();
            _clickPToShowPanelTmp.SetActive(!_clickPToShowPanelTmp.activeSelf);
        }

        private void UpdateControlsPanel()
        {
            _moveTmp.text = "Move: WASD and Arrows";
            _jumpTmp.text = "Jump: Space";
            _shootTmp.text = "Shoot: LMB";
            _reloadTmp.text = "Reload: R";
            _changeWeapon.text = "Change weapons: Scroll and slot number (1, 2, 3)";
        }
    }
}