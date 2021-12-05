using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    //clase que representa la posicion
   public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }

  
}
