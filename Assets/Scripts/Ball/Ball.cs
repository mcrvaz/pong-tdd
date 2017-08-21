using UnityEngine;

public class Ball : MonoBehaviour {

	public float speed;

	private BallMovement ballMovement;
	private Rigidbody2D rb;

	public void Construct(Rigidbody2D rb) {
		this.ballMovement = new BallMovement(speed);
		this.rb = rb;
	}

	void Awake() {
		Construct(GetComponent<Rigidbody2D>());
	}

	void Start () {
		rb.velocity = ballMovement.GetStartingDirection();
	}

}
