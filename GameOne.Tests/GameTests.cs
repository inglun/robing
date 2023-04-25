using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameOne.Tests {
	[TestClass]
	public class GameTests {
		Game sut;
		Mock<IGameInputOutput> io;

		[TestInitialize]
		public void Init() {
			io = new Mock<IGameInputOutput>(MockBehavior.Strict);
			sut = new Game(io.Object);
		}
		[TestCleanup]
		public void Cleanup() {
			io.VerifyAll();
		}

		[TestMethod]
		public void Run() {
			io.Setup(x => x.Say("bye"));
			io.Setup(x => x.PromptAndRead()).Returns("q");

			sut.Run();
		}
	}
}