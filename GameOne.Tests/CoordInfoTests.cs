using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GameOne.Tests {
	[TestClass]
	public class CoordInfoTests {
		[TestMethod]
		public void Pristine() {
			CoordInfo sut = new CoordInfo();

			Assert.AreEqual(0, sut.ShotsFiredAt);
			Assert.IsFalse(sut.HasTarget);
			Assert.AreEqual("#", sut.GetBoardSymbol());
		}
		[TestMethod]
		public void ShootAt_NoTarget() {
			CoordInfo sut = new CoordInfo();

			sut.ShootAt();

			Assert.AreEqual(1, sut.ShotsFiredAt);
			Assert.IsFalse(sut.HasTakenHit);
			Assert.AreEqual("O", sut.GetBoardSymbol());
		}
		[TestMethod]
		public void ShootAt_Target() {
			CoordInfo sut = new CoordInfo() { HasTarget = true };

			sut.ShootAt();

			Assert.AreEqual(1, sut.ShotsFiredAt);
			Assert.IsTrue(sut.HasTakenHit);
			Assert.AreEqual("X", sut.GetBoardSymbol());
		}
	}
}