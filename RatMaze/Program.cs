using System;
using System.Collections.Generic;

namespace RatMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            // Two-dimensional array.
            int[,] m_maze =
            {
                { 1, 0, 0, 0 },
                { 1, 1, 1, 1 },
                { 0, 1, 1, 0 },
                { 0, 1, 1, 1 }
            };

            int[,] m_visited = new int[m_maze.GetLength(0), m_maze.GetLength(1)];

            Console.WriteLine("Rat Maze");

            MazeSolver mz = new MazeSolver(m_maze);
            List<string> result = mz.ResolveMaze(new Coordinate { x = 0, y = 0 }, "", m_visited);

            result.ForEach(element => Console.WriteLine($"Element is {element}"));
        }
    }
}
