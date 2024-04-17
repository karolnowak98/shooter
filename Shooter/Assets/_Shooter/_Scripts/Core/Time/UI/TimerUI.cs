using UnityEngine;
using TMPro;
using GlassyCode.Shooter.Core.UI;

namespace GlassyCode.Shooter.Core.Time.UI
{
    public class TimerUI : Panel
    {
        [SerializeField] private TextMeshProUGUI _timeLeftTmp;
        [SerializeField] private uint _decimalPrecision;

        protected TextMeshProUGUI TimeLeftTmp => _timeLeftTmp;
        
        protected void SetTimeLeftTmp(float seconds)
        {
            _timeLeftTmp.text = string.Format($"{{0:F{_decimalPrecision}}}", seconds);
        }
    }
}