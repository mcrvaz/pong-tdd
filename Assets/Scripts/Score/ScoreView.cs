using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour {

	public Text text;

	void Awake() {
		Construct(GetComponent<Text>());
	}

	public void Construct(Text text) {
		this.text = text;
	}

	public void SetScore(int score) {
		if(score < 0) throw new System.ArgumentOutOfRangeException();
		this.text.text = score.ToString();
	}
}
