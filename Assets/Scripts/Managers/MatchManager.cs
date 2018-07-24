using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

    public float timeBeforeLaunch;

    private Ball ball;
    private ScoreManager scoreManager;
    private BallTimer ballTimer;
    private PowerupManager pwManager;

    public void Construct(Ball ball, ScoreManager scoreManager, BallTimer ballTimer, PowerupManager pwManager) {
        this.ball = ball;
        this.scoreManager = scoreManager;
        this.ballTimer = ballTimer;
        this.pwManager = pwManager;
    }

    void Awake() {
        var ball = GameObject.FindGameObjectWithTag(Tags.BALL).GetComponent<Ball>();
        var scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        var ballTimer = GameObject.FindObjectOfType<BallTimer>();
        var pwManager = GameObject.FindObjectOfType<PowerupManager>();
        Construct(ball, scoreManager, ballTimer, pwManager);
    }

    void Start() {
        this.pwManager.PauseGeneration();
        StartCoroutine(LaunchBall());
    }

    public void ScorePoint(Players player) {
        this.scoreManager.ScorePoint(player);
        this.ball.ResetPosition();
        this.ball.Hide();
        this.pwManager.PauseGeneration();
        StartCoroutine(LaunchBall());
    }

    private IEnumerator LaunchBall() {
        this.ballTimer.ShowTimer(timeBeforeLaunch);
        yield return new WaitForSeconds(timeBeforeLaunch);
        this.pwManager.ResumeGeneration();
        this.ballTimer.HideTimer();
        this.ball.Show();
        this.ball.Launch();
    }

}
