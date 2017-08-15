using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;

namespace Pong_TDD.Assets.Scripts.Tests.Editor
{
	public class BallMovementTest {

		public class CalculateStartingDirection : BallMovementTest {
			private BallMovement ballMovement;

			[SetUp]
			public void BeforeEachTest() {
				this.ballMovement = new BallMovement(2);
			}

			[Test]
			public void Sets_Random_X_Starting_Direction() {
				var randomX = 5;
				var random = Substitute.For<IRandom>();
				random.Value().Returns(randomX);
				ballMovement.randomProxy = random;

				Assert.AreEqual(
					randomX * ballMovement.speed,
					ballMovement.GetStartingDirection().x
				);
			}

			[Test]
			public void Sets_Random_Y_Starting_Direction_With_Speed() {
				var randomY = 5;
				var random = Substitute.For<IRandom>();
				random.Value().Returns(randomY);
				ballMovement.randomProxy = random;

				Assert.AreEqual(
					randomY * ballMovement.speed,
					ballMovement.GetStartingDirection().y
				);
			}
		}

	}
}
