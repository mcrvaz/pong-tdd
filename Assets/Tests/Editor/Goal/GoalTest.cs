using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

public class GoalTest {

	public class OnTriggerEnter2D {
        private Goal goal;
        private ScoreEvent scoreEvent;
        private BoxCollider2D ball;

        [SetUp]
		public void BeforeEachTest() {
			goal = new GameObject().AddComponent<Goal>();
			scoreEvent = Substitute.For<ScoreEvent>();
			ball = new GameObject().AddComponent<BoxCollider2D>();
			goal.Construct(Players.ONE, scoreEvent);
		}

		[Test]
		public void Does_Nothing_When_Collider_Tag_Is_Not_Ball() {
			goal.OnTriggerEnter2D(ball);
			scoreEvent.DidNotReceive().Invoke(Arg.Any<Players>());
		}

		[Test]
		public void Calls_ScoreEvent_When_Collider_Tag_Is_Ball() {
			ball.tag = Tags.BALL;
			goal.OnTriggerEnter2D(ball);
			scoreEvent.Received(3).Invoke(Arg.Any<Players>());
		}
	}

}
