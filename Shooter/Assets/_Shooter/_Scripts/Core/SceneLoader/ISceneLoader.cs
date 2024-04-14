namespace GlassyCode.Shooter.Core.SceneLoader
{
    public interface ISceneLoader
    {
         void LoadMenuScene();
         void LoadMenuSceneAsync();
         void LoadGameSceneAsync();
         void LoadGameScene();
    }
}
