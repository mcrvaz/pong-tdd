using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour {

	private Text textComponent;

	public int Score {
		get { return int.Parse(textComponent.text);  }
		set {
			if(value < 0) throw new System.ArgumentOutOfRangeException();
			this.textComponent.text = value.ToString();
		}
	}

	void Awake() {
		Construct(GetComponent<Text>());
	}

	public void Construct(Text text) {
		this.textComponent = text;
		this.Score = 0;
	}

}
