using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

public class PlayerTest {

	private float speed;
	private Player player;
	private Rigidbody2D rigidbody;

	[SetUp]
	public void BeforeEachTest() {
		this.speed = 2;
		var prefab = Resources.Load("Prefabs/Player");
		var go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
		player = go.GetComponent<Player>();
		player.GetComponent<Rigidbody2D>().position = Vector2.zero;
	}

	[UnityTest]
	public IEnumerator _Moves_Player_1_Times_Speed_Units_Vertically_Starting_At_0() {
		var inputProxy = Substitute.For<IInputProxy>();
		var timeProxy = Substitute.For<ITimeProxy>();
		var currentPosition = player.GetComponent<Rigidbody2D>().position;

		inputProxy.GetAxisRaw("Vertical").Returns(1);
		timeProxy.GetFixedDeltaTime().Returns(1);
		player.inputProxy = inputProxy;
		player.timeProxy = timeProxy;

		yield return new WaitForFixedUpdate();

		Assert.AreEqual(
			currentPosition.y + 1 * this.speed,
			player.GetComponent<Rigidbody2D>().position.y,
			0.1f);
	}
}
