using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement {

	public IRandom randomProxy;

	public BallMovement() {
		this.randomProxy = new RandomProxy();
	}

	public Vector2 GetStartingDirection() {
		return new Vector2(randomProxy.Value(), randomProxy.Value());
	}

}
