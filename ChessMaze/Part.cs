using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    public enum Part
    {
        Empty = (int)'E',
		King = (int)'K',		
		Rook = (int)'R',
		Bishop = (int)'B',
		Knight = (int)'N',	
		PlayerOnEmpty = (int)'e',
		PlayerOnKing = (int)'k',		
		PlayerOnRook = (int)'r',
		PlayerOnBishop = (int)'b',
		PlayerOnKnight = (int)'n'
    }
}
