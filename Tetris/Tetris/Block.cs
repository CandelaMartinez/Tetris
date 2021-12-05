using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    //clase de la que heredaran las demas clases block
   public abstract class Block
    {
        protected abstract Position [][] Tiles { get; }
        protected abstract Position StartOffset { get; }

        public abstract int Id { get; }

        private int rotationState;
        private Position offset;

        //en el constructor inicio offset con lo que hay dentro del objeto StartOffset del tipo Position
        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        //metodo que recorre le posicion actual y le agrega el offset al row y al column
        public IEnumerable<Position> TilePosition()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        //rotation 90 grados
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        //rotar en sentido de las agujas del reloj
        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        //metodo que mueve el block segun un numero de rows y columns
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        //metodo que resetea la rotacion y la posicion
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
