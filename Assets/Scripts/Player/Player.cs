using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] private float speed;

	public IInputProxy inputProxy;
	public ITimeProxy timeProxy;
	private PlayerMovement playerMovement;

	public void Construct(float speed) {
		this.playerMovement = new PlayerMovement(speed);
		this.inputProxy = new InputProxy();
		this.timeProxy = new TimeProxy();
	}

	void Awake() {
		Construct(speed);
	}

	void Update() {
		Debug.Log("alo");
		Move(inputProxy.GetAxisRaw("Vertical"), timeProxy.GetDeltaTime());
	}

	public void Move(float y, float deltaTime) {
		transform.position += (Vector3) this.playerMovement.CalculateMovement(y, deltaTime);
	}

}
