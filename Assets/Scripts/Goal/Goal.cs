using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScoreEvent : UnityEvent<Players>, IScoreEvent {}

public class Goal : MonoBehaviour {

	public Players scoresTo;
	public ScoreEvent scoreEvent;
	private IScoreEvent _scoreEvent { get; set; }

	public void Construct(Players scoresTo, IScoreEvent scoreEvent) {
		this.scoresTo = scoresTo;
		this._scoreEvent = scoreEvent;
	}

	public void Awake() {
		this.Construct(this.scoresTo, this.scoreEvent);
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == Tags.BALL) _scoreEvent.Invoke(scoresTo);
	}

}
