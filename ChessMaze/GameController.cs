using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    class GameController
    {
        private IView _view;
        private Game _game;

        public GameController(IView view, Game game)
        {
            _view = view;
            _game = game;
        }

        public void Go()
        {
            _view.Start();
            _game.Start
        }
    }
}
