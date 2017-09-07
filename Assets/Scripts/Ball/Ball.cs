using UnityEngine;

public class Ball : MonoBehaviour {

	public float speed;

	public BallMovement ballMovement { get; set; }
	private Rigidbody2D rb;
	private SpriteRenderer rend;

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

	void Start () {
		Launch();
	}

	public void Launch() {
		rb.velocity = ballMovement.GetStartingDirection();
	}

	public void ResetPosition() {
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0;
		transform.position = ballMovement.InitialPosition; //move instantly
		rb.Sleep(); //force stop
	}

	public void Hide() {
		rend.enabled = false;
	}

	public void Show() {
		rend.enabled = true;
	}

}
