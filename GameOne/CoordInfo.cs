﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne {
	public class CoordInfo {
		public bool HasTarget { get; set; }
		public int ShotsFiredAt { get; private set; }
		public bool ShootAt() {
			this.ShotsFiredAt = this.ShotsFiredAt + 1; 
			return this.HasTarget && this.ShotsFiredAt == 1;
		}
		public bool HasTakenHit {
			get {
				return this.HasTarget && this.ShotsFiredAt > 0;
			}
		}
		public bool Hittable { get { return this.HasTarget && this.ShotsFiredAt == 0; } }
		public string GetBoardSymbol() {
			if(this.ShotsFiredAt == 0) {
				return "#";
			}

			if(this.HasTakenHit) {
				return "O";
			} else {
				return "X";
			}
		}
	}
}
