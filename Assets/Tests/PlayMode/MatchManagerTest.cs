using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;
using System.Collections.Generic;

public class MatchManagerTest {

    private Ball ball;
	private Rigidbody2D ballRigidbody;
    private ScoreManager scoreManager;
    private MatchManager matchManager;

    private Ball CreateBall() {
		var ballGo = new GameObject();
		ballGo.tag = Tags.BALL;
		ballRigidbody = ballGo.AddComponent<Rigidbody2D>();
		var ball = ballGo.AddComponent<Ball>();
		ball.speed = 2;
		return ball;
	}

	private ScoreManager CreateScoreManager() {
		var go = new GameObject();
		var scoreManager = go.AddComponent<ScoreManager>();
		var scoreViewManager = Substitute.For<IScoreViewManager>();
		scoreViewManager.UpdateScore(Arg.Any<Dictionary<Players, int>>());
		scoreManager.Construct(scoreViewManager);
		return scoreManager;
	}

	[SetUp]
	public void BeforeEachTest() {
		ball = CreateBall();
		scoreManager = CreateScoreManager();
		matchManager = new GameObject().AddComponent<MatchManager>();
	}

	[TearDown]
	public void AfterEachTest() {
		GameObject.Destroy(ball.gameObject);
		GameObject.Destroy(scoreManager.gameObject);
		GameObject.Destroy(matchManager.gameObject);
	}

	public class ScorePoint : MatchManagerTest {
		[UnityTest]
		public IEnumerator Player_ONE_Points_Are_Increased_By_One() {
			var currentScore = scoreManager.Scores[Players.ONE];
			matchManager.ScorePoint(Players.ONE);
			yield return null;
			Assert.AreEqual(currentScore + 1, scoreManager.Scores[Players.ONE]);
		}

		[UnityTest]
		public IEnumerator Player_TWO_Points_Are_Increased_By_One() {
			var currentScore = scoreManager.Scores[Players.TWO];
			matchManager.ScorePoint(Players.TWO);
			yield return null;
			Assert.AreEqual(currentScore + 1, scoreManager.Scores[Players.TWO]);
		}

		[UnityTest]
		public IEnumerator Ball_Position_Is_Zero_After_Score() {
			ball.transform.position = Vector2.one;
			yield return null;
			matchManager.ScorePoint(Players.ONE);
			yield return null;
			Assert.AreEqual(0, ball.transform.position.x, 0.01);
			Assert.AreEqual(0, ball.transform.position.y, 0.01);
		}

		[UnityTest]
		public IEnumerator Ball_Velocity_Is_Zero_After_Score() {
			ballRigidbody.velocity = Vector2.one;
			yield return new WaitForFixedUpdate();
			matchManager.ScorePoint(Players.ONE);
			yield return new WaitForFixedUpdate();
			Assert.AreEqual(0, ballRigidbody.velocity.magnitude, 0.01);
		}

		// [UnityTest]
		// public IEnumerator Ball_Velocity_Is_Non_Zero_After_TimeBeforeLaunch_Seconds() {
		// 	ball.transform.position = Vector2.one;
		// 	yield return null;
		// 	matchManager.ScorePoint(Players.ONE);
		// 	yield return new WaitForSeconds(matchManager.timeBeforeLaunch + 1);
		// 	Assert.AreNotEqual(0, ballRigidbody.velocity.x);
		// 	Assert.AreNotEqual(0, ballRigidbody.velocity.y);
		// }
	}

}
