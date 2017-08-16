﻿using UnityEngine;
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
			public void Sets_Positive_1_Horizontal_Starting_Direction() {
				var random = Substitute.For<IRandom>();
				random.Range(Arg.Any<int>(), Arg.Any<int>()).Returns(1);
				ballMovement.randomProxy = random;

				Assert.AreEqual(
					1,
					ballMovement.GetStartingDirection().x / ballMovement.speed
				);
			}

			[Test]
			public void Sets_Negative_1_Horizontal_Starting_Direction() {
				var random = Substitute.For<IRandom>();
				random.Range(Arg.Any<int>(), Arg.Any<int>()).Returns(0);
				ballMovement.randomProxy = random;

				Assert.AreEqual(
					-1,
					ballMovement.GetStartingDirection().x / ballMovement.speed
				);
			}

			[Test]
			public void Sets_Positive_1_Vertical_Starting_Direction() {
				var random = Substitute.For<IRandom>();
				random.Range(Arg.Any<int>(), Arg.Any<int>()).Returns(1);
				ballMovement.randomProxy = random;

				Assert.AreEqual(
					1,
					ballMovement.GetStartingDirection().y / ballMovement.speed
				);
			}

			[Test]
			public void Sets_Negative_1_Vertical_Starting_Direction() {
				var random = Substitute.For<IRandom>();
				random.Range(Arg.Any<int>(), Arg.Any<int>()).Returns(0);
				ballMovement.randomProxy = random;

				Assert.AreEqual(
					-1,
					ballMovement.GetStartingDirection().y / ballMovement.speed
				);
			}
		}

	}
}
