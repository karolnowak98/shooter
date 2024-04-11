using UnityEngine;

namespace GlassyCode.Shooter.Core.Cursors
{
    public static class CursorController
    {
        public static void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        public static void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}