namespace ChessMaze
{
    public interface IGame
    {
        void Move(int nextRow, int nextCol);
        int GetMoveCount();
        void Undo();
        void Restart();
        bool IsFinished();
        void Start();
        void Load();
        void InputNextMove();
        Cell GetPlayerCell();
        void SetNextMove();
        Cell GetFinalCell();
        string GetTime();
        string End();
        void AddPiece(int row, int col, Part piece);
    }
}
