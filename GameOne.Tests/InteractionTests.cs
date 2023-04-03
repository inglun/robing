using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameOne.Tests {
	[TestClass]
	public class InteractionTests {
		Interaction sut;
		Mock<IInteractionInputOutput> io;

		[TestInitialize]
		public void Init() {
			io = new Mock<IInteractionInputOutput>(MockBehavior.Strict);
			sut = new Interaction(io.Object);
		}
		[TestCleanup]
		public void Cleanup() {
			io.VerifyAll();
		}

		[TestMethod]
		public void Run() {
			io.Setup(x => x.Prompt());
			io.Setup(x=>x.Read()).Returns(":q");

			sut.Run();
		}
		[TestMethod]
		public void RunInternal() {
			sut.RunInternal("qwe");
		}
	}
}