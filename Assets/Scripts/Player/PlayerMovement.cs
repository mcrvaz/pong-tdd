using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float inspectorSpeed;
    public float speed { get; private set; }

	private const float MOVE_MARGIN = 0.4f;
    private LayerMask boundsLayer;
	private new BoxCollider2D collider;
    private RaycastHit2D hitUp;
	private RaycastHit2D hitDown;

    void Awake() {
        this.speed = inspectorSpeed;
        this.boundsLayer = LayerMask.GetMask("Bound");
        this.collider = GetComponent<BoxCollider2D>();
    }

    public Vector2 CalculateMovement(Vector2 currentPosition, float y, float deltaTime) {
        float playerHeight = collider.bounds.extents.y;
        var newPosition = new Vector2(
            currentPosition.x,
            currentPosition.y + (y * speed * deltaTime)
        );
		// prevents player from bouncing
		hitUp = Physics2D.Raycast(currentPosition, Vector2.up, playerHeight + MOVE_MARGIN, boundsLayer.value);
		hitDown = Physics2D.Raycast(currentPosition, Vector2.down, playerHeight + MOVE_MARGIN, boundsLayer.value);
		if (hitUp.collider != null) {
			newPosition.y = Mathf.Min(newPosition.y, hitUp.point.y - playerHeight);
		} else if (hitDown.collider != null) {
			newPosition.y = Mathf.Max(newPosition.y, hitDown.point.y + playerHeight);
		}
        return newPosition;
    }

}
