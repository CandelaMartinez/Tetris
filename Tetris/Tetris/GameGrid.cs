using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this [int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        //constructor que inicializa las variables de clase
        public GameGrid (int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        //metodo que evalua si el row y el column esta o no dentro del grid
        //si r/c es mayor a cero y menor al numero de Rows/Columns
        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        //metodo que evalua si el cell esta vacio o no
        //tiene que estar dentro del grid y el valor debe ser 0
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        //metodo que evalua si el row inside esta lleno
        //recorre el array bidimensional
        public bool IsRowFull(int r)
        {
            for (int c=0; c< Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        //metodo que evalua si el row esta vacio
        //recorre el array bidimensional
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        //metodo que borra la row entera
        //se llama cuando el row esta llena
        private void ClearRow(int r)
        {
            for(int c=0; c< Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        //metodo que mueve abajo las rows en base a cierto numero
        private  void MoveRowDown(int r, int numRows)
        {
            for( int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        //metodo que borro todo el row
        
        public int ClearFullRows()
        {
            int cleared=0;

            for (int r = Rows-1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;

                }else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }

    }
}
