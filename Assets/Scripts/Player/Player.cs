using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;

	public IInput inputProxy;
	public ITime timeProxy;
	public string axis;

	private PlayerMovement playerMovement;
	private Rigidbody2D rb;

	private RaycastHit2D hitUp;
	private RaycastHit2D hitDown;
	private Vector2 newPosition;
	private LayerMask boundsLayer;

	public void Construct(float speed, Rigidbody2D rb, string axis) {
		this.playerMovement = new PlayerMovement(speed);
		this.inputProxy = new InputProxy();
		this.timeProxy = new TimeProxy();
		this.rb = rb;
		this.axis = axis;
		this.boundsLayer = LayerMask.GetMask("Bound");
	}

	void Awake() {
		Construct(Speed, GetComponent<Rigidbody2D>(), axis);
	}

	void FixedUpdate() {
		Move(inputProxy.GetAxisRaw(axis), timeProxy.GetFixedDeltaTime());
	}

	private void Move(float y, float deltaTime) {
		newPosition = playerMovement.CalculateMovement(rb.position, y, deltaTime);
		hitUp = Physics2D.Raycast(rb.position, Vector2.up, 2f, boundsLayer.value);
		hitDown = Physics2D.Raycast(rb.position, Vector2.down, 2f, boundsLayer.value);
		if (hitUp.collider != null) {
			newPosition.y = Mathf.Min(newPosition.y, hitUp.point.y - 1f);
		}
		if (hitDown.collider != null) {
			newPosition.y = Mathf.Max(newPosition.y, hitDown.point.y + 1f);
		}
		rb.MovePosition(newPosition);
	}

}
