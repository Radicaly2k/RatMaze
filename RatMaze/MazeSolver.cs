using System;
using System.Collections.Generic;

namespace RatMaze
{
    public struct Coordinate
    {
        public int x;
        public int y;
    }

    public class MazeSolver
    {

        int[,] m_visited;
        int[,] m_maze;

        List<string> paths = new List<string>();
        //Coordinate currentPos = new Coordinate { x = 0, y = 0 };
        //string currentPath = "";
        bool finish = true;

        public MazeSolver(int[,] maze)
        {
            //m_visited = new int[maze.GetLength(0), maze.GetLength(1)];
            m_maze = maze;
        }

        public List<string> ResolveMaze(Coordinate pos, string currentPath, int [,] visited)
        {
            if (CheckPos(pos))
            {
                RegisterVisitedCell(pos, visited);

                if (pos.x == m_maze.GetLength(0) - 1 && pos.y == m_maze.GetLength(1) - 1)
                {
                    if (finish)
                    {
                        // Reach the goal
                        paths.Add(currentPath);
                        return paths;
                    }
                }

                if (CheckDown(pos, visited))
                {
                    currentPath += "D";
                    Coordinate newPos = new Coordinate { x = pos.x + 1, y = pos.y };
                    ResolveMaze(newPos, currentPath, visited);
                    UnRegisterVisitedCell(newPos, visited);
                    currentPath = currentPath.Remove(currentPath.Length - 1);
                }

                if (CheckRight(pos, visited))
                {      
                    currentPath += "R";
                    Coordinate newPos = new Coordinate { x = pos.x, y = pos.y + 1 };
                    ResolveMaze(newPos, currentPath, visited);
                    UnRegisterVisitedCell(newPos, visited);
                    currentPath = currentPath.Remove(currentPath.Length - 1);
                }

                if (CheckLeft(pos, visited))
                {
                    currentPath += "L";
                    Coordinate newPos = new Coordinate { x = pos.x, y = pos.y - 1 };
                    ResolveMaze(newPos, currentPath, visited);
                    UnRegisterVisitedCell(newPos, visited);
                    currentPath = currentPath.Remove(currentPath.Length - 1);
                }

                if (CheckUp(pos, visited))
                {
                    currentPath += "U";
                    Coordinate newPos = new Coordinate { x = pos.x - 1, y = pos.y };
                    ResolveMaze(newPos, currentPath, visited);
                    UnRegisterVisitedCell(newPos, visited);
                    currentPath = currentPath.Remove(currentPath.Length - 1);
                }

                UnRegisterVisitedCell(pos, visited);
                return paths;
            }

            return paths;
        }

        public bool CheckPos(Coordinate pos)
        {
            if (pos.x >= 0 && pos.x < m_maze.GetLength(0) && pos.y >= 0 && pos.y < m_maze.GetLength(1) && m_maze[pos.x, pos.y] == 1)
            {
                return true;
            }
                
            return false;
        }

        public bool CheckDown(Coordinate pos, int [,] m_visited)
        {
            if (pos.x + 1 >= m_maze.GetLength(0))
            {
                return false;
            }

            if (m_visited[pos.x + 1, pos.y] == 1)
            {
                return false;
            }

            if (pos.x + 1 < m_maze.GetLength(0) && m_maze[pos.x + 1, pos.y] == 1)
            {
                return true;
            }

            return false;
        }

        public bool CheckUp(Coordinate pos, int[,] m_visited)
        {
            if (pos.x - 1 == -1)
            {
                return false;
            }

            if (m_visited[pos.x - 1, pos.y] == 1)
            {
                return false;
            }

            if (m_maze[pos.x - 1, pos.y] == 1)
            {
                return true;
            }

            return false;
        }

        public bool CheckRight(Coordinate pos, int[,] m_visited)
        {
            if (pos.y + 1 >= m_visited.GetLength(1))
            {
                return false;
            }

            if (m_visited[pos.x, pos.y + 1] == 1)
            {
                return false;
            }

            if (pos.y + 1 < m_maze.GetLength(1) && m_maze[pos.x, pos.y + 1] == 1)
            {
                return true;
            }

            return false;
        }

        public bool CheckLeft(Coordinate pos, int[,] m_visited)
        {
            if (pos.y - 1 == -1)
            {
                return false;
            }

            if (m_visited[pos.x, pos.y - 1] == 1)
            {
                return false;
            }

            if (m_maze[pos.x, pos.y - 1] == 1)
            {
                return true;
            }

            return false;
        }

        public void RegisterVisitedCell(Coordinate pos, int [,] m_visited)
        {
            m_visited[pos.x, pos.y] = 1;
        }

        public void UnRegisterVisitedCell(Coordinate pos, int [,] m_visited)
        {
            m_visited[pos.x, pos.y] = 0;
        }

        public void ResetVisitedMatrix()
        {
            m_visited = new int[m_maze.Length, m_maze.Length];
        }

    }
}