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
		var randomX = (randomProxy.Range(0, 2) * 2) - 1;
		var randomY = (randomProxy.Range(0, 2) * 2) - 1;
		return new Vector2(
			randomX * speed,
			randomY * speed
		);
	}

}
