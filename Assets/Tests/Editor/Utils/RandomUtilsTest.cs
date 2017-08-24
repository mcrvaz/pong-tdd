﻿using NUnit.Framework;
using NSubstitute;

public class RandomUtilsTest {

	public class Opposite {

		private RandomUtils randomUtils;

		[SetUp]
		public void BeforeEachTest() {
			this.randomUtils = new RandomUtils();
		}

		[Test]
		public void Should_Return_1() {
			var random = Substitute.For<IRandom>();
			random.Range(0, 0).ReturnsForAnyArgs(1);
			randomUtils.randomProxy = random;
			Assert.AreEqual(1, randomUtils.Opposite(1));
		}

		[Test]
		public void Should_Return_Minus_1() {
			var random = Substitute.For<IRandom>();
			random.Range(0, 0).ReturnsForAnyArgs(0);
			randomUtils.randomProxy = random;
			Assert.AreEqual(-1, randomUtils.Opposite(1));
		}

		[Test]
		public void Should_Return_2() {
			var random = Substitute.For<IRandom>();
			random.Range(0, 0).ReturnsForAnyArgs(1);
			randomUtils.randomProxy = random;
			Assert.AreEqual(2, randomUtils.Opposite(2));
		}

		[Test]
		public void Should_Return_Minus_2() {
			var random = Substitute.For<IRandom>();
			random.Range(0, 0).ReturnsForAnyArgs(0);
			randomUtils.randomProxy = random;
			Assert.AreEqual(-2, randomUtils.Opposite(2));
		}
	}
}
