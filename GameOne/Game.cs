﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne
{
    public class Game
    {
        int maxRows = 9;
        int maxCols = 5;
        Dictionary<Coordinate, string> map = new Dictionary<Coordinate, string>();
        int shootsFired;

        public void Init()
        {
            Random rnd = new Random();

            int numberTargets = 2;
            while (numberTargets > 0)
            {
                int randRow = rnd.Next(0, maxRows);
                int randCol = rnd.Next(0, maxCols);
                Coordinate randCoord = new Coordinate(randRow, randCol);
                if (!map.ContainsKey(randCoord))
                {
                    map.Add(randCoord, "mål");
                    numberTargets--;
                    Console.WriteLine(randCoord);
                }
            }
        }

        public void Run()
        {
            do
            {
                PrintBoard();
                Console.WriteLine("Row > ");
                string s = Console.ReadLine();
                int row = int.Parse(s);
                Console.WriteLine("Row: " + row);
                Console.WriteLine("Col > ");
                s = Console.ReadLine() ;
                int col = int.Parse(s);
                Console.WriteLine("Col: " + col);
                Coordinate coord = new Coordinate(row, col);
                ShootAt(coord);
            } while (TargetsLeft() > 0);
            PrintBoard();
            Console.WriteLine("bye!");
        }
        public void ShootAt(Coordinate position)
        {
            shootsFired++;
            if (!map.ContainsKey(position))
            {
                map.Add(position, "X");
            }
            else if (map[position] == "mål")
            {
                map[position] = "O";
            }
        }
        public void PrintBoard()
        {
            Console.WriteLine("Du har skjutit " + shootsFired + " skott. Du har " + TargetsLeft() + " mål kvar att skjuta ner.");
            for (int row = 0; row < maxRows; row++)
            {
                Console.Write(row + ": ");
                for (int col = 0; col < maxCols; col++)
                {
                    string val = "#";
                    Coordinate coord = new Coordinate(row, col);
                    if (map.ContainsKey(coord))
                    {
                        val = map[coord];
                        if (val == "mål")
                        {
                            val = "#";
                        }
                    }
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }
        int TargetsLeft()
        {
            return map.Values.Count(v => v == "mål");
        }
        
    }
}
