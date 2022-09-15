namespace ChessMaze
{
    public interface IGame
    {
        void Move();
        int GetMoveCount();
        void Undo();
        void Restart();
        bool IsFinished();
        void Start();
        void Load();
    }
}
