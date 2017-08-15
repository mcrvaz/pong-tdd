using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BallTest {

	private Ball ball;
	private Rigidbody2D rigidbody;

	[SetUp]
	public void BeforeEachTest() {
		var prefab = Resources.Load("Prefabs/Ball");
		var go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
		ball = go.GetComponent<Ball>();
		rigidbody = ball.GetComponent<Rigidbody2D>();
		rigidbody.position = Vector2.zero;
	}

	[UnityTest]
	public IEnumerator _Ball_Should_Start_Moving() {
		yield return new WaitForFixedUpdate();
		Assert.AreNotEqual(0, rigidbody.velocity.magnitude);
	}

}
