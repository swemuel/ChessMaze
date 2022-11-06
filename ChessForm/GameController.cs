using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessMaze;

namespace ChessForm
{
    public class GameController
    {
        private Form1 _view;
        private Game _game;

        public GameController(Form1 view, Game game)
        {
            _view = view;
            _game = game;
        }

        public void Go()
        {
            _game.Start();
            _view.Start(_game.GetPlayerCell()[0,0], _game.GetPlayerCell()[0, 1], _game.GetFinalCell()[0,0], _game.GetFinalCell()[0, 1]);
        }

        public void NextMove()
        {
            if (_game.IsFinished())
            {
                _view.EndGame();
            }
            else
            {
                int clickedRow = _view.clickedCell[0, 0];
                int clickedCol = _view.clickedCell[0, 1];
                _game.Move(clickedRow, clickedCol);
                _view.clickedCell = _game.GetPlayerCell();
                _view.NextMove(_game.GetPrevCell());
                _view.UpdateMoveCount(_game.GetMoveCount());
                if (_game.IsFinished())
                {
                    _view.EndGame();
                }
            }
        }
    }
}
