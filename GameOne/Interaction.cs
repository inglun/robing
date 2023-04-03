using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne {
	public interface IInteractionInputOutput {
		void Prompt();
		string Read();
	}

	public class Interaction {
		IInteractionInputOutput _output;

		public Interaction(IInteractionInputOutput output) {
			_output = output;
		}

		public void Run() {
			_output.Prompt();
			for(string uinp = _output.Read();this.KeepRunning(uinp);_output.Prompt(), uinp = _output.Read()) {
				this.RunInternal(uinp);
			}
		}
		internal void RunInternal(string uinp) {
			Console.WriteLine($"du skrev {uinp}");
		}

		internal bool KeepRunning(string uinp) {
			return uinp != null && uinp != ":q";
		}
	}
}
