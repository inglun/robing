using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne {
	public class Coordinate : Tuple<int, int> {
		public Coordinate(int row, int col) : base(row, col) {
		}
		public int Row => this.Item1;
		public int Col => this.Item2;
	}
}
