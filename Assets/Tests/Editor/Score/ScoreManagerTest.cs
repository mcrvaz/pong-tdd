using UnityEngine;
using NSubstitute;
using System.Collections.Generic;
using NUnit.Framework;

public class ScoreManagerTest {

	public class ScorePoint {

        private ScoreManager scoreManager;

        [SetUp]
		public void BeforeEachTest() {
			var go = new GameObject();
			var scoreViewManager = Substitute.For<IScoreViewManager>();
			scoreViewManager.UpdateScore(Arg.Any<Dictionary<Players, int>>());
			this.scoreManager = go.AddComponent<ScoreManager>();
			this.scoreManager.Construct(scoreViewManager);
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

		[Test]
		public void Visible_Score_Is_Updated() {
			var score = scoreManager.ScorePoint(Players.ONE);
			scoreManager.scoreViewManager.Received().UpdateScore(score);
		}
	}

}
