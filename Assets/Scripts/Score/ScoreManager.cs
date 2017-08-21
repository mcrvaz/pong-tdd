using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Dictionary<Players, int> Scores { get; private set; }
	public IScoreViewManager scoreViewManager { get; private set; }

    public void Construct(IScoreViewManager scoreViewManager) {
		this.Scores = new Dictionary<Players, int>();
		this.scoreViewManager = scoreViewManager;
		foreach(Players p in System.Enum.GetValues(typeof(Players))) {
			Scores.Add(p, 0);
		}
	}

	void Awake() {
		this.Construct(GetComponent<ScoreViewManager>());
	}

    public void ScorePoint(Players player) {
		this.Scores[player]++;
		UpdateScores();
	}

	private void UpdateScores() {
		this.scoreViewManager.UpdateScore(this.Scores);
	}
}
