using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    class FormView : IView
    {
        public int ShowMoveCount()
        {
            return 1;
        }

        public string ShowTimer()
        {
            return "";
        }

        public string End()
        {
            return "";
        }

        public void Start()
        {

        }
    }
}
