namespace ChessMaze
{
    public interface IGame
    {
        int[,] Move(int nextRow, int nextCol);
        int GetMoveCount();
        bool IsFinished();
        void Start();
        void Load();
        int[,] GetPlayerCell();
        int[,] GetPrevCell();
        int[,] GetFinalCell();
        void AddPiece(int row, int col, Part piece);
    }
}
