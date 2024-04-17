namespace GlassyCode.Shooter.Core.UI.Logic
{
    public interface IDialogue
    {
        void EnqueueLine(string characterLine, string playerLine);
        DialogueLine? GetNextLine();
    }
}