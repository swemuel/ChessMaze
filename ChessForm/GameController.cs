using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessMaze;

namespace ChessForm
{
    class GameController
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
            Application.Run(_view);
        }
    }
}
