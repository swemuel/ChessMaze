namespace ChessMaze
{
    public interface IGame
    {
        int[,] Move(int nextRow, int nextCol);
        int GetMoveCount();
        void Undo();
        void Restart();
        bool IsFinished();
        void Start();
        void Load();
        void InputNextMove();
        int[,] GetPlayerCell();
        void SetNextMove();
        int[,] GetFinalCell();
        string GetTime();
        string End();
        void AddPiece(int row, int col, Part piece);
    }
}
