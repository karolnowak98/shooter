using System;
using UnityEngine;

namespace GlassyCode.Shooter.Game.Player.Data
{
    [Serializable]
    public struct MovementData
    {
        [Header("Movement Speed")]
        [Tooltip("The base movement speed of the player.")]
        [SerializeField]
        private float _moveSpeed;

        [Header("Max Movement Speed")]
        [Tooltip("The maximum movement speed of the player.")]
        [SerializeField]
        private float _maxMoveSpeed;

        [Header("Player Height")]
        [Tooltip("The height of the player character.")]
        [SerializeField]
        private float _playerHeight;

        [Header("Jumping")]
        [Tooltip("The force applied when jumping.")]
        [SerializeField]
        private float _jumpForce;

        [Tooltip("The cooldown time between jumps.")]
        [SerializeField]
        private float _jumpCooldown;

        [Tooltip("Multiplier applied to movement while in the air.")]
        [SerializeField]
        private float _airMultiplier;

        [Header("Other Properties")]
        [Tooltip("The drag force applied to the player.")]
        [SerializeField]
        private float _dragForce;

        [Tooltip("Layer mask used to detect the ground.")]
        [SerializeField]
        private LayerMask _groundMask;

        public float MoveSpeed => _moveSpeed;
        public float MaxMoveSpeed => _maxMoveSpeed;
        public float PlayerHeight => _playerHeight;
        public float JumpForce => _jumpForce;
        public float JumpCooldown => _jumpCooldown;
        public float AirMultiplier => _airMultiplier;
        public float DragForce => _dragForce;
        public LayerMask GroundMask => _groundMask;
    }
}