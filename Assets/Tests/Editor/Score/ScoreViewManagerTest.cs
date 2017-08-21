using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;
using System.Collections.Generic;

public class ScoreViewManagerTest {

	public class UpdateScore {

        private ScoreViewManager scoreViewManager;
        private Dictionary<Players, int> newScore;

        [SetUp]
		public void BeforeEachTest() {
			scoreViewManager = new GameObject().AddComponent<ScoreViewManager>();
			newScore = new Dictionary<Players, int>();
		}

		private List<ScoreView> GetScoreViewList(int size) {
			var scores = new List<ScoreView>();
			for (int i = 0; i < size; i++) {
				var go = new GameObject();
				var scoreView = go.AddComponent<ScoreView>();
				scoreView.Construct(go.AddComponent<Text>());
				scores.Add(scoreView);
			}
			return scores;
		}

		[Test]
		public void Score_For_Player_ONE_Is_Updated_To_1() {
			var scores = this.GetScoreViewList(1);
			newScore.Add(Players.ONE, 1);
			scoreViewManager.Construct(scores);

			scoreViewManager.UpdateScore(newScore);

			Assert.AreEqual(scoreViewManager.visibleScore[Players.ONE].Score, 1);
		}

		[Test]
		public void Score_For_Player_TWO_is_Updated_To_1() {
			var scores = this.GetScoreViewList(2);
			newScore.Add(Players.ONE, 0);
			newScore.Add(Players.TWO, 1);
			scoreViewManager.Construct(scores);

			scoreViewManager.UpdateScore(newScore);

			Assert.AreEqual(scoreViewManager.visibleScore[Players.TWO].Score, 1);
		}

	}

}
