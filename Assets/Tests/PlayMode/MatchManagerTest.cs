using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;
using System.Collections.Generic;

public class MatchManagerTest {

    private Ball ball;
    private ScoreManager scoreManager;
    private MatchManager matchManager;

    private Ball CreateBall() {
		var ballGo = new GameObject();
		ballGo.tag = Tags.BALL;
		ballGo.AddComponent<Rigidbody2D>();
		ballGo.AddComponent<SpriteRenderer>();
		var ball = ballGo.AddComponent<Ball>();
		ball.ballMovement.speed = 1;
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

	private MatchManager CreateMatchManager() {
		var matchManager = new GameObject().AddComponent<MatchManager>();
		matchManager.timeBeforeLaunch = 0.1f;
		return matchManager;
	}

	[SetUp]
	public void BeforeEachTest() {
		ball = CreateBall();
		scoreManager = CreateScoreManager();
		matchManager = CreateMatchManager();
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
			ball.GetComponent<Rigidbody2D>().velocity = Vector2.one;
			yield return new WaitForFixedUpdate();
			matchManager.ScorePoint(Players.ONE);
			yield return new WaitForFixedUpdate();
			Assert.AreEqual(0, ball.GetComponent<Rigidbody2D>().velocity.magnitude);
		}

		[UnityTest]
		public IEnumerator Ball_Is_Invisible_After_Score() {
			matchManager.ScorePoint(Players.ONE);
			yield return null;
			Assert.IsFalse(ball.GetComponent<SpriteRenderer>().enabled);
		}

		[UnityTest]
		public IEnumerator Ball_Velocity_Is_Non_Zero_After_TimeBeforeLaunch_Seconds() {
			ball.transform.position = Vector2.one;
			yield return null;
			matchManager.ScorePoint(Players.ONE);
			yield return new WaitForSeconds(matchManager.timeBeforeLaunch);
			Assert.AreNotEqual(0, ball.GetComponent<Rigidbody2D>().velocity.magnitude);
		}

		[UnityTest]
		public IEnumerator Ball_Is_Visible_After_TimeBeforeLaunch_Seconds() {
			matchManager.ScorePoint(Players.ONE);
			yield return new WaitForSeconds(matchManager.timeBeforeLaunch);
			Assert.IsTrue(ball.GetComponent<SpriteRenderer>().enabled);
		}

	}

}
