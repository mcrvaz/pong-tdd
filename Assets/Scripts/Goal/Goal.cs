using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour {
	[System.Serializable]
	public class ScoreEvent : UnityEvent<Players> {}

	public Players scoresTo;
	public ScoreEvent scoreEvent;

	public void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == Tags.BALL) scoreEvent.Invoke(scoresTo);
	}

}
