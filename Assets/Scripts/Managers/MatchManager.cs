using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

    public float timeBeforeLaunch;

    private Ball ball;
    private ScoreManager scoreManager;

    public void Construct(Ball ball, ScoreManager scoreManager) {
        this.ball = ball;
        this.scoreManager = scoreManager;
    }

    void Awake() {
        var ball = GameObject.FindGameObjectWithTag(Tags.BALL).GetComponent<Ball>();
        var scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        Construct(ball, scoreManager);
    }

    public void ScorePoint(Players player) {
        this.scoreManager.ScorePoint(player);
        this.ball.ResetPosition();
        this.ball.Hide();
        StartCoroutine(LaunchBall());
    }

    private IEnumerator LaunchBall() {
        yield return new WaitForSeconds(timeBeforeLaunch);
        this.ball.Show();
        this.ball.Launch();
    }

}
