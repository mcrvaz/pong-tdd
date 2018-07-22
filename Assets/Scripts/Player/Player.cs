using UnityEngine;

public class Player : MonoBehaviour {

	public float Speed;

	public IInput inputProxy;
	public ITime timeProxy;
	public string axis;
	public Player initialState { get; private set; }

	private PlayerMovement playerMovement;
	private Rigidbody2D rb;
	private new BoxCollider2D collider;

	private RaycastHit2D hitUp;
	private RaycastHit2D hitDown;
	private Vector2 newPosition;
	private LayerMask boundsLayer;
	private const float MOVE_MARGIN = 0.4f;

	public void Construct(float speed, Rigidbody2D rb, string axis, BoxCollider2D collider) {
		this.playerMovement = new PlayerMovement(speed);
		this.inputProxy = new InputProxy();
		this.timeProxy = new TimeProxy();
		this.boundsLayer = LayerMask.GetMask("Bound");
		this.rb = rb;
		this.axis = axis;
		this.collider = collider;
	}

	void Awake() {
		Construct(Speed, GetComponent<Rigidbody2D>(), axis, GetComponent<BoxCollider2D>());
	}

	void Start() {
		this.initialState = this.Clone();
	}

	void FixedUpdate() {
		Move(inputProxy.GetAxisRaw(axis), timeProxy.GetFixedDeltaTime());
	}

	private void Move(float y, float deltaTime) {
		float playerHeight = collider.bounds.extents.y;
		newPosition = playerMovement.CalculateMovement(rb.position, y, deltaTime);
		hitUp = Physics2D.Raycast(rb.position, Vector2.up, playerHeight + MOVE_MARGIN, boundsLayer.value);
		hitDown = Physics2D.Raycast(rb.position, Vector2.down, playerHeight + MOVE_MARGIN, boundsLayer.value);
		if (hitUp.collider != null) {
			newPosition.y = Mathf.Min(newPosition.y, hitUp.point.y - playerHeight);
		} else if (hitDown.collider != null) {
			newPosition.y = Mathf.Max(newPosition.y, hitDown.point.y + playerHeight);
		}
		rb.MovePosition(newPosition);
	}

	private Player Clone() {
		var cloneGo = (GameObject) Instantiate(
			gameObject,
			transform.position,
			transform.rotation
		);
		cloneGo.SetActive(false);
		return cloneGo.GetComponent<Player>();
	}

}
