namespace GameOne.Tests {
	[TestClass]
	public class CoordInfoTests {
		[TestMethod]
		public void ShootAt_NoTarget() {
			CoordInfo sut = new CoordInfo();

			sut.ShootAt();

			Assert.AreEqual(1, sut.ShotsFiredAt);
			Assert.IsFalse(sut.HasTarget);
		}
		[TestMethod]
		public void ShootAt_Target() {
			CoordInfo sut = new CoordInfo() { HasTarget = true };

			sut.ShootAt();

			Assert.AreEqual(1, sut.ShotsFiredAt);
			Assert.IsTrue(sut.HasTarget);
		}
	}
}