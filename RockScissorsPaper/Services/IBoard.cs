namespace RockScissorsPaper.Services
{
    public interface IBoard
    {
        Winner PlayRock();
    }

    public enum Winner
    {
        None,
        User,
        Computer
    }
}