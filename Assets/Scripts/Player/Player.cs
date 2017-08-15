using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;

	public IInput inputProxy;
	public ITime timeProxy;

	private PlayerMovement playerMovement;
	private Rigidbody2D rb;

    public void Construct(float speed, Rigidbody2D rb) {
		this.playerMovement = new PlayerMovement(speed);
		this.rb = rb;
		this.inputProxy = new InputProxy();
		this.timeProxy = new TimeProxy();
	}

	void Awake() {
		Construct(Speed, GetComponent<Rigidbody2D>());
	}

	void FixedUpdate() {
		Move(inputProxy.GetAxisRaw("Vertical"), timeProxy.GetFixedDeltaTime());
	}

	private void Move(float y, float deltaTime) {
		var newPosition = this.playerMovement.CalculateMovement(rb.position, y, deltaTime);
		rb.MovePosition(newPosition);
	}

}
