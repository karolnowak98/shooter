using GlassyCode.Shooter.Core.Data;
using UnityEngine;

namespace GlassyCode.Shooter.Game.Missions.Data
{
    [CreateAssetMenu(menuName = "Configs/Missions Config", fileName = "Missions Config")]
    public class MissionsConfig : Config
    {
        [SerializeField] private MissionData[] _missionData;

        public MissionData[] MissionData => _missionData;
    }
}