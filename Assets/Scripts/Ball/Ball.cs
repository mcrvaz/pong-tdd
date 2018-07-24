using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {

	public float speed;
	public BallMovement ballMovement { get; set; }

	private Rigidbody2D rb;
	private SpriteRenderer rend;
	private float timeWithoutColliding;
	private const float MAX_TIME_WITHOUT_COLLIDING = 8f;

	public void Construct(Rigidbody2D rb, SpriteRenderer rend) {
		this.ballMovement = new BallMovement(speed, transform.position);
		this.rb = rb;
		this.rend = rend;
	}

	void Awake() {
		Construct(
			GetComponent<Rigidbody2D>(),
			GetComponent<SpriteRenderer>()
		);
	}

	void Update() {
		timeWithoutColliding -= Time.deltaTime;
		if (timeWithoutColliding <= 0) ResetPosition(); // prevent ball from going away forever
	}

	void OnCollisionEnter2D(Collision2D col) {
		timeWithoutColliding = MAX_TIME_WITHOUT_COLLIDING;
	}

	public void Launch() {
		rb.velocity = ballMovement.GetStartingDirection();
		timeWithoutColliding = MAX_TIME_WITHOUT_COLLIDING;
	}

	public void ResetPosition() {
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0;
		transform.position = ballMovement.InitialPosition; // move instantly
		rb.Sleep(); // force stop
	}

	public void Hide() {
		rend.enabled = false;
	}

	public void Show() {
		rend.enabled = true;
	}

}
