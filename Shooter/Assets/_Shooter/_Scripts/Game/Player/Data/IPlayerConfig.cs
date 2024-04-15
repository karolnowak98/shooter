namespace GlassyCode.Shooter.Game.Player.Data
{
    public interface IPlayerConfig
    {
        CameraData CameraData { get; }
        MovementData MovementData { get; }
    }
}