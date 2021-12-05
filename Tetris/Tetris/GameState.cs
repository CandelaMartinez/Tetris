using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {
        private Block currentBlock;
        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();

                for(int i=0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);
                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                        
                    }
                }
            }
        }

        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }

        public int Score { get; private set; }

        public Block HeldBlock { get; private set; }
        public bool CanHold { get; private set; }

        //inicio el grid con 22 rows y 10 columns
        //inicio el BlockQueue y lo uso para obtener el random block para el current block
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
            CanHold = true;


        }

        //metodo que ve si mi block esta en una posicion correcta o no
        //si alguno esta afuera del grid o arriba de otro tile, false
        //uso metodo IsEmpty()
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePosition())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }

            }
            return true;
        }

        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }
            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            else
            {
                Block tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = tmp;
            }

            CanHold = false;
        }

        //metodo que rota el block en sentido de las agujas del reloj, solo si es posible
        //roto el block, si termina en una posicion ilegal, lo roto a la posicion anterios
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        //metodo inverso al anterior
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        //metodos para mover los blocks a la derecha e izquierda
        //los muevo, si estan en una ilegal position, los muevo de vuelta a la posicion anterior
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        //metodo que ve si el juego se termino
        //si las dos hidden rows de arriba estan NO vacias, el game is over
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        //metodo llamado cuando el currentBlock no puede ser movido abajo
        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePosition())
            {
                GameGrid[p.Row, p.Column] = currentBlock.Id;
            }
           Score += GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
                CanHold = true;
            }

        }
        //metodo que mueve abajo el block, llama al metodo PlaceBlock en caso de que no pueda ser movido
        //placeBlock chequea que el game no este over
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);
            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        private int TileDropDistance(Position p)
        {
            int drop = 0;
            while(GameGrid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }
            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;
            foreach(Position p in CurrentBlock.TilePosition())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }
            return drop;
        }

        public void DropBlock()
        {
            currentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }







    }
}