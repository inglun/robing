using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne {
	public interface IOutput {
		void Say(string message);
	}
	public interface IInteractionInputOutput : IOutput {
		string PromptAndRead();
	}

	public class Interaction {
		readonly IInteractionInputOutput _io;
		Scene _scene;

		public Interaction(IInteractionInputOutput io, Scene scene) {
			_io = io;
			_scene = scene;
		}

		bool _keepRunning;
		public void Run() {
			_scene.DescribeScene();
			_keepRunning = true;
			while(_keepRunning) {
				var uinp = _io.PromptAndRead();
				this.RunInternal(uinp);
			}
		}
		internal void RunInternal(string uinp) {
			if(uinp == null)
				throw new ArgumentNullException(nameof(uinp));

			if(uinp.StartsWith(":"))
				this.HandleGlobalCommand(uinp.Substring(1));
			else
				_scene.ReactTo(uinp);
		}

		internal void HandleGlobalCommand(string cmd) {
			switch(cmd) {
			case "?":
				_scene.DescribeScene();
				break;
			case "q":
				_keepRunning = false;
				break;
			}
		}

		internal bool KeepRunning(string uinp) {
			return uinp != null && uinp != ":q";
		}
	}
}
