using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GameOne.Tests {
	[TestClass]
	public class CoordInfoTests {
		[TestMethod]
		public void Pristine() {
			CoordInfo sut = new CoordInfo();

			Assert.AreEqual(0, sut.ShotsFiredAt);
			Assert.IsFalse(sut.HasTarget);
			Assert.IsFalse(sut.Hittable);
			Assert.AreEqual("#", sut.GetBoardSymbol());
		}
		[TestMethod]
		public void ShootAt_NoTarget() {
			CoordInfo sut = new CoordInfo();

			bool res = sut.ShootAt();

			Assert.IsFalse(res);
			Assert.AreEqual(1, sut.ShotsFiredAt);
			Assert.IsFalse(sut.HasTakenHit);
			Assert.AreEqual("X", sut.GetBoardSymbol());
		}
		[TestMethod]
		public void HittableWhenHasTargetAndNoShootsFired() {
			CoordInfo sut = new CoordInfo() { HasTarget = true };

			Assert.IsTrue(sut.Hittable);
		}
		[TestMethod]
		public void ShootAt_Target() {
			CoordInfo sut = new CoordInfo() { HasTarget = true };

			bool res = sut.ShootAt();

			Assert.IsTrue(res);
			Assert.AreEqual(1, sut.ShotsFiredAt);
			Assert.IsTrue(sut.HasTakenHit);
			Assert.IsFalse(sut.Hittable);
			Assert.AreEqual("O", sut.GetBoardSymbol());
		}
	}
}