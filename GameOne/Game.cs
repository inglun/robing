using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne
{
    public class Game
    {
        int maxRows = 8;
        int maxCols = 8;
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
                ShootAt(GetCoordinateToShootAtFromUser());
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
                Console.WriteLine("Sploosh!");
            }
            else if (map[position] == "mål")
            {
                map[position] = "O";
                Console.WriteLine("Kaboom!");
            }
        }
        

        public Coordinate GetCoordinateToShootAtFromUser()
        {
            int row = -1;
            int col = -1;
            bool keepAsking = true;
            do
            {
                try
                {
                    Console.Write("Enter coordinates > ");
                    string s = Console.ReadLine();
                    string[] parts = s.Split(' ');
                    row = int.Parse(parts[0]);
                    if (row > maxRows || row < 0)
                    {
                        throw new ArgumentOutOfRangeException("row", "X-koordinaten ligger utanför brädet!");
                    }
                    col = int.Parse(parts[1]);
                    if (col > maxCols || col < 0)
                    {
                        throw new ArgumentOutOfRangeException("col", "Y-koordinaten ligger utanför brädet!");
                    }
                    keepAsking = false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message} Försök igen!");
                }
            } while (keepAsking);
            Console.WriteLine("Shooting at: " + row + ", " + col);
            return new Coordinate(row, col);
        }
        public void PrintBoard()
        {
            Console.WriteLine("Du har skjutit " + shootsFired + " skott. Du har " + TargetsLeft() + " mål kvar att skjuta ner.");
            Console.WriteLine();
            Console.Write("   ");
            for (int col = 0; col < maxCols; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
            Console.Write("   ");
            for (int col = 0; col < maxCols; col++)
            {
                Console.Write("¨ ");
            }
            Console.WriteLine() ;
            for (int row = 0; row < maxRows; row++)
            {
                Console.Write(row + ": ");
                for (int col = 0; col < maxCols; col++)
                {
                    string val = "#";
                    Coordinate coord = new Coordinate(row, col);
                    if (map.ContainsKey(coord) && map[coord] != "mål")
                    {
                        val = map[coord];
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
