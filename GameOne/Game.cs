using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne {
	public class Game {
		int max = 9;
		Dictionary<int, string> map = new Dictionary<int, string>();
		int shootsFired;

		public void Init() {
            /*// Math.Rand
			//abcdef
			Random rnd = new Random();
			int rand_num = rnd.Next(0,max);
			//Console.WriteLine(rand_num);
            Random rnd2 = new Random();
            int rand_num2 = rnd2.Next(0,max);
			//Console.WriteLine(rand_num2);
			if (rand_num2 == rand_num) {
				Init();
			}
            map.Add(rand_num, "mål");
			map.Add(rand_num2, "mål");
			shootsFired = 0;*/
            Random rnd = new Random();

            int numberTargets = 2;
            while (numberTargets > 0)
            {
                int rand_num = rnd.Next(0, max); // ska det vara max eller max-1
                if (!map.ContainsKey(rand_num))
                {
                    map.Add(rand_num, "mål");
                    numberTargets--;
                    Console.WriteLine(rand_num);
                }
            }
        }

		public void Run() {
			do {
				PrintBoard();
				Console.Write("> ");
				string s = Console.ReadLine();
				int pos = int.Parse(s);
				Console.WriteLine("du skrev " + pos);
				ShootAt(pos);
			} while(TargetsLeft() > 0);
			PrintBoard();
			Console.WriteLine("bye!");
		}
		public void ShootAt(int position) {
			shootsFired++;
			if(!map.ContainsKey(position)) {
				map.Add(position, "X");
			} else if(map[position] == "mål") {
				map[position] = "O";
			}
		}
		public void PrintBoard() {
			Console.WriteLine("Du har skjutit " + shootsFired + " skott. Du har " + TargetsLeft() + " mål kvar att skjuta ner.");
			for(int i = 0;i < max;i++) {
				if(map.ContainsKey(i)) {
					string val = map[i];
					if(val == "mål") {
						val = "#";
					}
					Console.WriteLine(i + ": " + val);
				} else {
					Console.WriteLine(i + ": #");
				}
			}
		}
		int TargetsLeft() {
			return map.Values.Count(v => v == "mål");
		}
		int NotInUse() {
			int res = 0;
			for(int i = 0;i < max;i++) {
				if(map.ContainsKey(i) && map[i] == "mål") {
					res++;
				}
			}
			return res;
		}
	}
}
