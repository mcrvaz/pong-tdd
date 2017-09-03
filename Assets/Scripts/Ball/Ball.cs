using UnityEngine;

public class Ball : MonoBehaviour {

	public float speed;

	public BallMovement ballMovement { get; set; }
	private Rigidbody2D rb;

	public void Construct(Rigidbody2D rb) {
		this.ballMovement = new BallMovement(speed, transform.position);
		this.rb = rb;
	}

	void Awake() {
		Construct(GetComponent<Rigidbody2D>());
	}

	void Start () {
		Launch();
	}

	public void Launch() {
		rb.velocity = ballMovement.GetStartingDirection();
	}

	public void ResetPosition() {
		rb.velocity = Vector2.zero;
		rb.position = ballMovement.InitialPosition;
	}

}
