namespace GlassyCode.Shooter.Core.UI
{
    public interface IDialogue
    {
        void EnqueueLine(string characterLine, string playerLine);
        DialogueLine? GetNextLine();
    }
}