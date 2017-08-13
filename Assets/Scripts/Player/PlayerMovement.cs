using UnityEngine;
public class PlayerMovement {
    public float Speed { get; set; }

    public PlayerMovement(float speed){
        this.Speed = speed;
    }

    public Vector2 CalculateMovement(float y, float deltaTime) {
        return new Vector2(0, y * Speed * deltaTime);
    }

}