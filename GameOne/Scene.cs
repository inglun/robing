using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne {
	public class Scene {
		IGameOutput _outp;

		public Scene(IGameOutput outp) {
			_outp = outp;
		}

		public void DescribeScene() {
			_outp.Say("".PadRight(80, '*'));
			_outp.Say("Detta är en scene");
			_outp.Say("".PadRight(80, '*'));
		}

		public void ReactTo(string uinp) {
			if(uinp != null && uinp.StartsWith(":"))
				throw new ArgumentException($"global commands are not supposed to be dispatch to a {this.GetType()}");

			_outp.Say($"du skrev {uinp}");
		}
	}
}
