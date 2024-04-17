using GlassyCode.Shooter.Core.UI;

namespace GlassyCode.Shooter.Game.DustMap.UI
{
    public interface IDustMapDialogue : IDialogue
    {
        DialogueLine SuccessLine { get; }
        DialogueLine FailureLine { get; }
    }
}