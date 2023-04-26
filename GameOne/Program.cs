// See https://aka.ms/new-console-template for more information
using GameOne;

namespace GameOne {
	public class Program {
		private static void Main(string[] args) {
			Console.WriteLine("Hello, GameOne!");

			var game = new Game();
			game.Init();
			game.Run();
		}
	}
}
