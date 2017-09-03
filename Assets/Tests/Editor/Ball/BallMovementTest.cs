using UnityEngine;
using NUnit.Framework;
using NSubstitute;

public class BallMovementTest {

	public class CalculateStartingDirection : BallMovementTest {
		private BallMovement ballMovement;
		private RandomUtils randomUtils;

		[SetUp]
		public void BeforeEachTest() {
			this.randomUtils = new RandomUtils();
			this.ballMovement = new BallMovement(2, Vector2.zero);
		}

		[Test]
		public void Sets_Positive_1_Horizontal_Starting_Direction() {
			var random = Substitute.For<IRandom>();
			random.Range(0, 0).ReturnsForAnyArgs(1);
			randomUtils.randomProxy = random;
			ballMovement.random = randomUtils;

			Assert.AreEqual(
				1,
				ballMovement.GetStartingDirection().x / ballMovement.speed
			);
		}

		[Test]
		public void Sets_Negative_1_Horizontal_Starting_Direction() {
			var random = Substitute.For<IRandom>();
			random.Range(0, 0).ReturnsForAnyArgs(0);
			randomUtils.randomProxy = random;
			ballMovement.random = randomUtils;

			Assert.AreEqual(
				-1,
				ballMovement.GetStartingDirection().x / ballMovement.speed
			);
		}

		[Test]
		public void Sets_Positive_1_Vertical_Starting_Direction() {
			var random = Substitute.For<IRandom>();
			random.Range(0, 0).ReturnsForAnyArgs(1);
			randomUtils.randomProxy = random;
			ballMovement.random = randomUtils;

			Assert.AreEqual(
				1,
				ballMovement.GetStartingDirection().y / ballMovement.speed
			);
		}

		[Test]
		public void Sets_Negative_1_Vertical_Starting_Direction() {
			var random = Substitute.For<IRandom>();
			random.Range(0, 0).ReturnsForAnyArgs(0);
			randomUtils.randomProxy = random;
			ballMovement.random = randomUtils;

			Assert.AreEqual(
				-1,
				ballMovement.GetStartingDirection().y / ballMovement.speed
			);
		}
	}

}
