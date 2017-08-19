using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Dictionary<Players, int> Scores { get; private set; }

    public void Construct() {
		this.Scores = new Dictionary<Players, int>();
		foreach(Players p in System.Enum.GetValues(typeof(Players))) {
			Scores.Add(p, 0);
		}
	}

	void Awake() {
		this.Construct();
	}

    public Dictionary<Players, int> ScorePoint(Players player) {
		this.Scores[player]++;
		return this.Scores;
	}
}
