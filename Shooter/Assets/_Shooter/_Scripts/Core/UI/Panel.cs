﻿using UnityEngine;

namespace GlassyCode.Shooter.Core.UI
{
    public class Panel : MonoBehaviour
    {
        protected void Show() => gameObject.SetActive(true);
        protected void Hide() => gameObject.SetActive(false);

        protected void ToggleVisibility()
        {
            if (gameObject.activeSelf)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }
}