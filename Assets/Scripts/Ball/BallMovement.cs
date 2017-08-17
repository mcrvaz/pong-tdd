using UnityEngine;

public class BallMovement {

	public RandomUtils random;
	public float speed;

	public BallMovement(float speed) {
		this.random = new RandomUtils();
		this.speed = speed;
	}

	public Vector2 GetStartingDirection() {
		return new Vector2(
			random.Opposite(1) * speed,
			random.Opposite(1) * speed
		);
	}

}
