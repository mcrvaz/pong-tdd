using UnityEngine;
using NUnit.Framework;

public class ScoreManagerTest {

	public class ScorePoint {

        private ScoreManager scoreManager;

        [SetUp]
		public void BeforeEachTest() {
			this.scoreManager = new GameObject().AddComponent<ScoreManager>();
			this.scoreManager.Construct();
		}

		[Test]
		public void Player1_Scores_1_Point() {
			var score = scoreManager.ScorePoint(Players.ONE);
			Assert.AreEqual(1, score[Players.ONE]);
		}

		[Test]
		public void Player2_Scores_1_Point() {
			var score = scoreManager.ScorePoint(Players.TWO);
			Assert.AreEqual(1, score[Players.TWO]);
		}
	}

}
