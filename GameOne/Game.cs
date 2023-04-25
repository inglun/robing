using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne {
	public interface IGameOutput {
		void Say(string message);
	}
	public interface IGameInputOutput : IGameOutput {
		string PromptAndRead();
	}

	public class Game {
		readonly IGameInputOutput _io;

		public Game(IGameInputOutput io) {
			_io = io;
		}

		bool _keepRunning;
		public void Run() {
			_keepRunning = true;
			while(_keepRunning) {
				var uinp = _io.PromptAndRead();
				switch(uinp) {
				case "q":
					_io.Say("bye");
					_keepRunning = false;
					break;
				default:
					_io.Say($"Du sa '{uinp}'");
					break;
				}
			}
		}
	}
}
