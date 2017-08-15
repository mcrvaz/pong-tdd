using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement {

	public IRandom randomProxy;
	public float speed;

	public BallMovement(float speed) {
		this.randomProxy = new RandomProxy();
		this.speed = speed;
	}

	public Vector2 GetStartingDirection() {
		return new Vector2(randomProxy.Value() * speed, randomProxy.Value() * speed);
	}

}
