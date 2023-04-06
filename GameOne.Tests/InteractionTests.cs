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
			sut = new Interaction(io.Object, new Scene(io.Object));
		}
		[TestCleanup]
		public void Cleanup() {
			io.VerifyAll();
		}

		[TestMethod]
		public void Run() {
			io.Setup(x => x.PromptAndRead()).Returns(":q");

			sut.Run();
		}
		[TestMethod]
		public void RunInternal() {
			io.Setup(x => x.Say("du skrev qwe"));

			sut.RunInternal("qwe");
		}
	}
}