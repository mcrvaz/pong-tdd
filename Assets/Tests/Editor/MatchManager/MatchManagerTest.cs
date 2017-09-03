using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MatchManagerTest {

	public class ResetBallPosition {

		[Test]
		public void Ball_Position_Is_Set_To_Zero_With_Non_Zero_Starting_Position() {
			var matchManager = new GameObject().AddComponent<MatchManager>();
			var ball = new GameObject().AddComponent<Ball>();
			ball.transform.position = Vector2.one;
			matchManager.Construct(ball);

			matchManager.ResetBallPosition();
			Assert.AreEqual(Vector3.zero, ball.transform.position);
		}

	}

}
