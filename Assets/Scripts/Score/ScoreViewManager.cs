using System.Collections.Generic;
using UnityEngine;

public class ScoreViewManager : MonoBehaviour, IScoreViewManager {

	[SerializeField] private List<ScoreView> currentScore;
	public Dictionary<Players, ScoreView> visibleScore;

	public void Construct(List<ScoreView> currentScore) {
		var players = System.Enum.GetValues(typeof(Players));
		visibleScore = new Dictionary<Players, ScoreView>();

		for (int i = 0; i < currentScore.Count; i++) {
			var p = (Players) players.GetValue(i);
			visibleScore[p] = currentScore[i];
		}
	}

	public void Awake() {
		this.Construct(currentScore);
	}

	public virtual void UpdateScore(Dictionary<Players, int> newScore) {
		foreach(KeyValuePair<Players, int> s in newScore) {
			visibleScore[s.Key].Score = newScore[s.Key];
		}
	}

}
