using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

    private Ball ball;

    public void Construct(Ball ball) {
        this.ball = ball;
    }

    void Awake() {
        Construct(
            GameObject.FindGameObjectWithTag(Tags.BALL).GetComponent<Ball>()
        );
    }

    public void ResetBallPosition() {
        this.ball.transform.position = Vector2.zero;
    }

}
