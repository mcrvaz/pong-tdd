using UnityEngine;

public class BallMovement {

	public RandomUtils random;
	public float speed;
	public Vector2 InitialPosition { get; private set; }

	public BallMovement(float speed, Vector2 initialPosition) {
		this.random = new RandomUtils();
		this.speed = speed;
		this.InitialPosition = initialPosition;
	}

	public Vector2 GetStartingDirection() {
		return new Vector2(
			random.Opposite(1) * speed,
			random.Opposite(1) * speed
		);
	}

}
