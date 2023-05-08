using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne {
	public class Game {
		int maxRows = 8;
		int maxCols = 8;
		Dictionary<Coordinate, CoordInfo> map = new Dictionary<Coordinate, CoordInfo>();
		int shootsFired;

		public void Init() {
			for(int r = 0;r < maxRows;r++) {
				for(int c = 0;c < maxCols;c++) {
					map.Add(new Coordinate(r, c), new CoordInfo());
				}
			}

			Random rnd = new Random();

			int numberTargets = 2;
			while(numberTargets > 0) {
				int randRow = rnd.Next(0, maxRows);
				int randCol = rnd.Next(0, maxCols);
				Coordinate randCoord = new Coordinate(randRow, randCol);
				CoordInfo coordInfo = map[randCoord];
				if(!coordInfo.HasTarget) {
					coordInfo.HasTarget = true;
					numberTargets--;
					Console.WriteLine(randCoord);
				}
			}
		}

		public void Run() {
			do {
				PrintBoard();
				ShootAt(GetCoordinateToShootAtFromUser());
			} while(TargetsLeft() > 0);
			PrintBoard();
			Console.WriteLine("bye!");
		}
		public void ShootAt(Coordinate position) {
			shootsFired++;
			CoordInfo coordInfo = map[position];
			bool hit = coordInfo.ShootAt();
			if(hit) {
				Console.WriteLine("Kaboom!");
			} else {
				Console.WriteLine("Sploosh!");
			}
		}


		public Coordinate GetCoordinateToShootAtFromUser() {
			int row = -1;
			int col = -1;
			bool keepAsking = true;
			do {
				try {
					Console.Write("Enter coordinates > ");
					string s = Console.ReadLine();
					string[] parts = s.Split(' ');
					row = int.Parse(parts[0]);
					if(row > maxRows || row < 0) {
						throw new ApplicationException("X-koordinaten ligger utanför brädet!");
					}
					col = int.Parse(parts[1]);
					if(col > maxCols || col < 0) {
						throw new ApplicationException("Y-koordinaten ligger utanför brädet!");
					}
					Coordinate position = new Coordinate(row, col);
					CoordInfo coordInfo = map[position];
					if (coordInfo.ShotsFiredAt == 1) {
						throw new ApplicationException("Skjut någon annanstans!");
					}
					// TODO: throw om man redan har skjutit "här". Titta på t.ex. rad 27 o 28
					keepAsking = false;
				} catch(Exception ex) {
					Console.WriteLine($"{ex.Message} Försök igen!");
				}
			} while(keepAsking);
			Console.WriteLine("Shooting at: " + row + ", " + col);
			return new Coordinate(row, col);
		}
		public void PrintBoard() {
			Console.WriteLine("Du har skjutit " + shootsFired + " skott. Du har " + TargetsLeft() + " mål kvar att skjuta ner.");
			Console.WriteLine();
			Console.Write("   ");
			for(int col = 0;col < maxCols;col++) {
				Console.Write(col + " ");
			}
			Console.WriteLine();
			Console.Write("   ");
			for(int col = 0;col < maxCols;col++) {
				Console.Write("¨ ");
			}
			Console.WriteLine();
			for(int row = 0;row < maxRows;row++) {
				Console.Write(row + ": ");
				for(int col = 0;col < maxCols;col++) {
					Coordinate coord = new Coordinate(row, col);
					CoordInfo coordInfo = map[coord];
					string val = coordInfo.GetBoardSymbol();
					//string val = "#";
					//if(map.ContainsKey(coord) && map[coord] != "mål") {
					//	val = map[coord];
					//}
					Console.Write(val + " ");
				}
				Console.WriteLine();
			}
		}
		int TargetsLeft() {
			return map.Values.Count(v => v.Hittable);
		}

	}
}
