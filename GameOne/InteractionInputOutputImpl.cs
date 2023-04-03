using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne {
	public class InteractionInputOutputImpl : IInteractionInputOutput {
		public void Prompt() {
			Console.Write("> ");
		}
		public string Read() {
			return Console.ReadLine();
		}
	}
}
