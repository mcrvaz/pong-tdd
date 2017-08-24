using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScoreEvent : UnityEvent<Players> {}

public class Goal : MonoBehaviour {

	public Players scoresTo;
	public ScoreEvent scoreEvent;

	public void Construct(Players scoresTo, ScoreEvent scoreEvent) {
		this.scoresTo = scoresTo;
		this.scoreEvent = scoreEvent;
	}

	public void Awake() {
		this.Construct(this.scoresTo, this.scoreEvent);
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == Tags.BALL) scoreEvent.Invoke(scoresTo);
	}

}
