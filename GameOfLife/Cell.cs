using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Cell
    {
        private bool alive;
        private bool nextState;
        private Cell[] neighbors;

        public Cell(bool alive)
        {
            this.alive = alive;
        }

        public void setNeighbors(Cell[] neighbors)
        {
            this.neighbors = neighbors;
        }

        /// <summary>
        /// Returns the state of the cell, in terms of being alive.
        /// </summary>
        public bool getState()
        {
            return alive;
        }

        public void applyNextState()
        {
            alive = nextState;
        }

        public int getValue()
        {
            if (alive == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return 0;
            }
        }

        public void calculateState()
        {
            int liveCount = 0;

            for (int i = 0; i < neighbors.Count(); i++)
            {
                if (neighbors[i].getState() == true)
                {
                    liveCount += 1;

                }
            }

            //Rule 1 of the game of life.
            if (liveCount < 2)
            {
                //Kill the cell.
                nextState = false;
            }



            //Rule 3 of the game of life.
            if (liveCount > 3)
            {
                //Kill the cell.
                nextState = false;

            }

            //Rule 4 of the game of life.
            if (liveCount == 3)
            {
                nextState = true;
            }

        }


    }
}
