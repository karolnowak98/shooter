using System.Collections.Generic;
using ModestTree;

namespace GlassyCode.Shooter.Core.UI.Logic
{
    public abstract class Dialogue
    {
        private readonly Queue<DialogueLine> _lines = new();
        
        //private bool IsLastLine =>_lines.Count <= 1;

        public virtual void EnqueueLine(string characterLine, string playerLine)
        {
            _lines.Enqueue(new DialogueLine
            {
                CharacterLine = characterLine,
                PlayerLine = playerLine
            });
        }
        
        public virtual DialogueLine? GetNextLine()
        {
            if (_lines.IsEmpty()) return null;
            
            return _lines.Dequeue();
        }
    }
}