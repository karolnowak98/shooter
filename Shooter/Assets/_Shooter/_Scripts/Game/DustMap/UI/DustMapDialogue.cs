using GlassyCode.Shooter.Core.UI.Logic;

namespace GlassyCode.Shooter.Game.DustMap.UI
{
    public sealed class DustMapDialogue : Dialogue, IDustMapDialogue
    {
        public DialogueLine SuccessLine { get; }
        public DialogueLine FailureLine { get; }
        
        public DustMapDialogue(DialogueLine successLine, DialogueLine failureLine)
        {
            SuccessLine = successLine;
            FailureLine = failureLine;
        }
    }
}