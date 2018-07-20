using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

    public float timeBeforeLaunch;

    private Ball ball;
    private ScoreManager scoreManager;
    private BallTimer ballTimer;

    public void Construct(Ball ball, ScoreManager scoreManager, BallTimer ballTimer) {
        this.ball = ball;
        this.scoreManager = scoreManager;
        this.ballTimer = ballTimer;
    }

    void Awake() {
        var ball = GameObject.FindGameObjectWithTag(Tags.BALL).GetComponent<Ball>();
        var scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        var ballTimer = GameObject.FindObjectOfType<BallTimer>();
        Construct(ball, scoreManager, ballTimer);
    }

    void Start() {
        StartCoroutine(LaunchBall());
    }

    public void ScorePoint(Players player) {
        this.scoreManager.ScorePoint(player);
        this.ball.ResetPosition();
        this.ball.Hide();
        StartCoroutine(LaunchBall());
    }

    private IEnumerator LaunchBall() {
        this.ballTimer.ShowTimer(timeBeforeLaunch);
        yield return new WaitForSeconds(timeBeforeLaunch);
        this.ballTimer.HideTimer();
        this.ball.Show();
        this.ball.Launch();
    }

}
