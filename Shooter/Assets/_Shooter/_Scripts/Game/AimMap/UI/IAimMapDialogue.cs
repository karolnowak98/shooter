using GlassyCode.Shooter.Core.UI.Logic;

namespace GlassyCode.Shooter.Game.AimMap.UI
{
    public interface IAimMapDialogue : IDialogue
    {
        DialogueLine SuccessLine { get; }
        DialogueLine FailureLine { get; }
    }
}