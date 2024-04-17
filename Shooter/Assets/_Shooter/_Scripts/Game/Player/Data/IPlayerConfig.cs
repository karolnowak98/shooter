namespace GlassyCode.Shooter.Game.Player.Data
{
    public interface IPlayerConfig
    {
        PlayerData PlayerData { get; }
        CameraData CameraData { get; }
        MovementData MovementData { get; }
    }
}