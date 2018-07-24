using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour {

	public IInput inputProxy;
	public ITime timeProxy;
	public string axis;

	public Player initialState { get; private set; }

	private PlayerMovement playerMovement;
	private Rigidbody2D rb;

	public void Construct(PlayerMovement playerMovement, Rigidbody2D rb, string axis) {
		this.inputProxy = new InputProxy();
		this.timeProxy = new TimeProxy();
		this.playerMovement = playerMovement;
		this.rb = rb;
		this.axis = axis;
	}

	void Awake() {
		Construct(GetComponent<PlayerMovement>(), GetComponent<Rigidbody2D>(), axis);
	}

	void Start() {
		this.initialState = this.Clone();
	}

	void FixedUpdate() {
		Move(inputProxy.GetAxisRaw(axis), timeProxy.GetFixedDeltaTime());
	}

	private void Move(float y, float deltaTime) {
		rb.MovePosition(playerMovement.CalculateMovement(rb.position, y, deltaTime));
	}

	private Player Clone() {
		GameObject cloneGo = (GameObject) Instantiate(
			gameObject,
			transform.position,
			transform.rotation
		);
		cloneGo.SetActive(false);
		return cloneGo.GetComponent<Player>();
	}

}
