﻿using UnityEngine;

namespace GlassyCode.Shooter.Game.Props.Logic
{
    public class OpenDoorReaction : DestroyReaction
    {
        protected override void HandleDestroyReaction()
        {
            Debug.Log("Door has been opened!");
        }
    }
}