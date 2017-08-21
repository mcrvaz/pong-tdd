using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreViewTest {

	public class SetScore {

        private ScoreView scoreView;

        [SetUp]
		public void BeforeEachTest() {
			var go = new GameObject();
			var text = go.AddComponent<Text>();
			this.scoreView = go.AddComponent<ScoreView>();
			this.scoreView.Construct(text);
		}

		[Test]
		public void Score_Starts_At_0() {
			Assert.AreEqual(0, scoreView.Score);
		}

		[Test]
		public void Set_Score_Equals_1() {
			scoreView.Score = 1;
			Assert.AreEqual(1, scoreView.Score);
		}

		[Test]
		public void Throws_Expection_Negative_Score() {
			Assert.Throws<System.ArgumentOutOfRangeException>(() => scoreView.Score = -1);
		}

		[Test]
		public void Return_Current_Score_Equals_1() {
			scoreView.Score = 1;
			Assert.AreEqual(1, scoreView.Score);
		}
	}

}
