using System;
using UnityEngine;

namespace GlassyCode.Shooter.Game.Player.Data
{
    [Serializable]
    public struct PlayerData
    {
        [Header("Transform")] 
        [SerializeField]
        private Vector3 _startingPosition;
        
        [SerializeField]
        private Vector3 _startingRotation;
        
        public Vector3 StartingPosition => _startingPosition;
        public Vector3 StartingRotation => _startingRotation;
    }
}