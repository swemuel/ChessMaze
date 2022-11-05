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
            Trace.WriteLine(_game.GetPlayerCell().ToString());
            Console.WriteLine(_game.GetFinalCell());
            _view.Start(_game.GetPlayerCell()[0,0], _game.GetPlayerCell()[0, 1], _game.GetFinalCell()[0,0], _game.GetFinalCell()[0, 1]);
        }

        private void NextMove()
        {
            while (_game.GetPlayerCell() == _view.clickedCell)
            {

            }
            _game.Move(_view.clickedCell[0, 0], _view.clickedCell[0, 1]);
            _view.clickedCell = _game.Move(_view.clickedCell[0, 0], _view.clickedCell[0, 1]);
            Console.WriteLine(_game.GetPlayerCell());
            NextMove();  
        }
    }
}
