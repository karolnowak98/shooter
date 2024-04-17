using GlassyCode.Shooter.Core.UI.Logic;

namespace GlassyCode.Shooter.Game.AimMap.UI
{
    public class AimMapDialogue : Dialogue, IAimMapDialogue
    {
        public DialogueLine SuccessLine { get; }
        public DialogueLine FailureLine { get; }
        
        public AimMapDialogue(DialogueLine successLine, DialogueLine failureLine)
        {
            SuccessLine = successLine;
            FailureLine = failureLine;
        }
    }
}