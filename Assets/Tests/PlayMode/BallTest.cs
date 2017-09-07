using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class BallTest : BasePlayTest {

	private Ball ball;
	private Rigidbody2D rigidbody;
	private Vector2 initialPosition;

	[SetUp]
	public virtual void BeforeEachTest() {
		var prefab = Resources.Load("Prefabs/Ball");
		initialPosition = Vector3.one;
		go = GameObject.Instantiate(
			prefab, initialPosition, Quaternion.identity
		) as GameObject;
		ball = go.GetComponent<Ball>();
		rigidbody = ball.GetComponent<Rigidbody2D>();
	}

	public class Awake : BallTest {
		[UnityTest]
		public IEnumerator Starting_Position_Should_Be_Stored() {
			yield return null;
			Assert.AreEqual(initialPosition, ball.ballMovement.InitialPosition);
		}
	}

	public class Start : BallTest {
		[UnityTest]
		public IEnumerator Ball_Should_Start_With_Non_Zero_Velocity() {
			yield return new WaitForFixedUpdate();
			Assert.AreNotEqual(0, rigidbody.velocity.magnitude);
		}
	}

	public class Launch : BallTest {
		//should refactor to test if ball velocity is equal to starting velocity
		[UnityTest]
		public IEnumerator Ball_Velocity_Should_Be_Non_Zero() {
			rigidbody.velocity = Vector2.zero;
			yield return new WaitForFixedUpdate();
			ball.Launch();
			yield return new WaitForFixedUpdate();
			Assert.AreNotEqual(Vector2.zero, rigidbody.velocity);
		}
	}

	public class ResetPosition : BallTest {
		[UnityTest]
		public IEnumerator Ball_Should_Go_Back_To_Initial_Position() {
			rigidbody.position = Vector2.zero;
			yield return new WaitForFixedUpdate();
			ball.ResetPosition();
			yield return new WaitForFixedUpdate();
			Assert.AreEqual(
				rigidbody.position, ball.ballMovement.InitialPosition
			);
		}

		[UnityTest]
		public IEnumerator Ball_Should_Have_Zero_Velocity() {
			rigidbody.position = Vector2.zero;
			yield return new WaitForFixedUpdate();
			ball.ResetPosition();
			yield return new WaitForFixedUpdate();
			Assert.AreEqual(
				Vector2.zero, rigidbody.velocity
			);
		}
	}

	public class Hide : BallTest {
		[UnityTest]
		public IEnumerator Ball_Should_Not_Be_Visibile_After_Being_Visible() {
			ball.GetComponent<SpriteRenderer>().enabled = true;
			ball.Hide();
			yield return null;
			Assert.IsFalse(ball.GetComponent<SpriteRenderer>().enabled);
		}
	}

	public class Show : BallTest {
		[UnityTest]
		public IEnumerator Ball_Should_Be_Visibile_After_Being_Invisible() {
			ball.GetComponent<SpriteRenderer>().enabled = false;
			ball.Show();
			yield return null;
			Assert.IsTrue(ball.GetComponent<SpriteRenderer>().enabled);
		}
	}

}
