using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace GameOfLife
{
    class Program
    {
        static int width = 60;
        static int height = 25;
        static int generation = 0;

        static void Main(string[] args)
        {
            Random rand = new Random();
            Cell[,] cells = new Cell[height, width];
            bool exit = false;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (rand.Next(100) < 50)
                    {
                        cells[y, x] = new Cell(true);
                    }
                    else
                    {
                        cells[y, x] = new Cell(false);
                    }
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[y, x].setNeighbors(getNeighbors(cells, y, x));
                }
            }

            int timer = 0;

            while (exit == false)
            {
                if (timer == 0)
                {
                    generation += 1;
                    DrawCells(cells);
                    UpdateCells(cells);
                    timer = 60000000;
                }
                else
                {
                    timer -= 1;
                }
            }

            Console.Read();
        }

        static Cell[] getNeighbors(Cell[,] cells, int y, int x)
        {
            List<Cell> neighbors = new List<Cell>();

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        if ((y + i) > -1 && (y + i) < height)
                        {
                            if ((x + j) > -1 && (x + j) < width)
                            {
                                neighbors.Add(cells[(y + i), (x + j)]);
                            }
                        }
                    }
                }
            }

            return neighbors.ToArray();
        }

        static void DrawCells(Cell[,] cells)
        {
            Console.Clear();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(cells[y, x].getValue());
                }

                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Generation : " + generation);
        }

        static void UpdateCells(Cell[,] cells)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[y, x].calculateState();
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[y, x].applyNextState();
                }
            }
        }
    }
}
