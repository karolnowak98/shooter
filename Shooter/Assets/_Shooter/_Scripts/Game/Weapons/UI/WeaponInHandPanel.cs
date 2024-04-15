﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.Props.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic.Shooting;

namespace GlassyCode.Shooter.Game.Weapons.UI
{
    public class WeaponInHandPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _ammoInMagazineTmp;
        [SerializeField] private TextMeshProUGUI _ammoTotalTmp;
        [SerializeField] private TextMeshProUGUI _destroyMaterialTmp;
        [SerializeField] private Image _ammoIcon;
        [SerializeField] private Image _weaponIcon;
        [SerializeField] private Slider _reloadSlider;

        private IWeaponManager _weaponManager;
        private IShootingController _shootingController;

        [Inject]
        private void Construct(IWeaponManager weaponManager, IShootingController shootingController)
        {
            _weaponManager = weaponManager;
            _shootingController = shootingController;

            _weaponManager.OnWeaponChanged += UpdateWeaponPanel;
            _shootingController.OnShoot += UpdateAmmo;
        }
        
        private void OnDestroy()
        {
            _weaponManager.OnWeaponChanged -= UpdateWeaponPanel;
            _shootingController.OnShoot -= UpdateAmmo;
        }

        private void Awake()
        {
            UpdateWeaponPanel();
        }
        
        private void UpdateWeaponPanel()
        {
            var weapon = _weaponManager.WeaponInHand;
            var data = weapon.WeaponEntity;

            _destroyMaterialTmp.text = "Destroy: " + string.Join(", ", data.DestroyMaterials);
            _ammoIcon.sprite = data.AmmoIcon;
            _weaponIcon.sprite = data.Icon;
            
            UpdateAmmo();
            UpdateReloadSliderVisibility(false);
            
            weapon.OnReloadProgressChanged += UpdateReloadSlider;
            weapon.OnReloadStart += () => UpdateReloadSliderVisibility(true);
        }
        
        private void UpdateAmmo(IDestroyable hitObject = null)
        {
            _ammoInMagazineTmp.text = $"{_weaponManager.WeaponInHand.AmmoInMagazine}";
            _ammoTotalTmp.text = $"{_weaponManager.WeaponInHand.TotalAmmo}";
        }

        private void UpdateReloadSlider(float progress)
        {
            if (progress >= 1)
            {
                UpdateReloadSliderVisibility(false);
                UpdateAmmo();
            }

            _reloadSlider.value = progress;
        }

        private void UpdateReloadSliderVisibility(bool isVisible)
        {
            _reloadSlider.gameObject.SetActive(isVisible);
        }
    }
}