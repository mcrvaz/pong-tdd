using UnityEngine;
public class PlayerMovement {
    public float Speed { get; set; }

    public PlayerMovement(float speed){
        this.Speed = speed;
    }

    public Vector2 CalculateMovement(Vector2 currentPosition, float y, float deltaTime) {
        return new Vector2(
            currentPosition.x,
            currentPosition.y + y * Speed * deltaTime
        );
    }

}