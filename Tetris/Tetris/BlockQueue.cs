using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    //clase responsable de elegir el proximo bloque
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock(),
        };
        private readonly Random random = new Random();

        public Block NextBlock {get; private set;}

        //constructor que inicializa el proximo block con un random block
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        //preview the next block
        //metodo que devuelve un random block
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        //metodo que setea el block con el proximo block
        //lo sigue haciendo mientras que se repita el block, asi tenemos uno diferente
        public Block GetAndUpdate()
        {
            Block block = NextBlock;
            do
            {
                NextBlock = RandomBlock();

            } while (block.Id == NextBlock.Id);

            return block;
        }

    }
}
