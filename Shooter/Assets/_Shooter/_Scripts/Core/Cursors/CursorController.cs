using UnityEngine;

namespace GlassyCode.Shooter.Core.Cursors
{
    public sealed class CursorController : ICursorController
    {
        public void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        public void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}