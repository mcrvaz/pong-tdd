using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

public class PlayerTest {

	private Player player;
	private Rigidbody2D rigidbody;

	[SetUp]
	public void BeforeEachTest() {
		var prefab = Resources.Load("Prefabs/Player");
		var go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
		player = go.GetComponent<Player>();
		rigidbody = player.GetComponent<Rigidbody2D>();
		rigidbody.position = Vector2.zero;
	}

	[UnityTest]
	public IEnumerator _Moves_Player_1_Times_Speed_Units_Vertically_Starting_At_0() {
		var inputProxy = Substitute.For<IInput>();
		var timeProxy = Substitute.For<ITime>();
		var currentPosition = rigidbody.position;
		inputProxy.GetAxisRaw("Vertical").Returns(1);
		timeProxy.GetFixedDeltaTime().Returns(1);
		player.inputProxy = inputProxy;
		player.timeProxy = timeProxy;

		yield return new WaitForFixedUpdate();

		Assert.AreEqual(
			1 * player.Speed,
			rigidbody.position.y,
			0.1f
		);
	}

	[UnityTest]
	public IEnumerator _Moves_Player_1_Times_Speed_Units_Vertically_Starting_At_1() {
		var inputProxy = Substitute.For<IInput>();
		var timeProxy = Substitute.For<ITime>();
		var currentPosition = rigidbody.position;
		rigidbody.position = Vector2.one;
		inputProxy.GetAxisRaw("Vertical").Returns(1);
		timeProxy.GetFixedDeltaTime().Returns(1);
		player.inputProxy = inputProxy;
		player.timeProxy = timeProxy;

		yield return new WaitForFixedUpdate();

		Assert.AreEqual(
			(1 * player.Speed) + 1,
			rigidbody.position.y,
			0.1f
		);
	}

	[UnityTest]
	public IEnumerator _Moves_Player_2_Times_Speed_Units_Vertically_Starting_At_0() {
		var inputProxy = Substitute.For<IInput>();
		var timeProxy = Substitute.For<ITime>();
		var currentPosition = rigidbody.position;
		inputProxy.GetAxisRaw("Vertical").Returns(2);
		timeProxy.GetFixedDeltaTime().Returns(1);
		player.inputProxy = inputProxy;
		player.timeProxy = timeProxy;

		yield return new WaitForFixedUpdate();

		Assert.AreEqual(
			2 * player.Speed,
			rigidbody.position.y,
			0.1f
		);
	}

	[UnityTest]
	public IEnumerator _Moves_Player_2_Times_Speed_Units_Vertically_Starting_At_1() {
		var inputProxy = Substitute.For<IInput>();
		var timeProxy = Substitute.For<ITime>();
		var currentPosition = rigidbody.position;
		rigidbody.position = Vector2.one;
		inputProxy.GetAxisRaw("Vertical").Returns(2);
		timeProxy.GetFixedDeltaTime().Returns(1);
		player.inputProxy = inputProxy;
		player.timeProxy = timeProxy;

		yield return new WaitForFixedUpdate();

		Assert.AreEqual(
			(2 * player.Speed) + 1,
			rigidbody.position.y,
			0.1f
		);
	}
}
