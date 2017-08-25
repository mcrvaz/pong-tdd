using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;

	public IInput inputProxy;
	public ITime timeProxy;
	public string axis;

	private PlayerMovement playerMovement;
	private Rigidbody2D rb;

    public void Construct(float speed, Rigidbody2D rb, string axis) {
		this.playerMovement = new PlayerMovement(speed);
		this.rb = rb;
		this.inputProxy = new InputProxy();
		this.timeProxy = new TimeProxy();
		this.axis = axis;
	}

	void Awake() {
		Construct(Speed, GetComponent<Rigidbody2D>(), this.axis);
	}

	void FixedUpdate() {
		Move(inputProxy.GetAxisRaw(axis), timeProxy.GetFixedDeltaTime());
	}

	private void Move(float y, float deltaTime) {
		var newPosition = this.playerMovement.CalculateMovement(rb.position, y, deltaTime);
		rb.MovePosition(newPosition);
	}

}
