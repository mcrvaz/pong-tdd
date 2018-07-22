using UnityEngine;
using UnityEngine.UI;

public class BallTimer : MonoBehaviour {

	public float currentTimer { get; private set; }

	private Text textComponent;

	void Awake() {
		textComponent = GetComponent<Text>();
	}

	void Update () {
		if (currentTimer > 0) currentTimer -= Time.deltaTime;
		textComponent.text = ((int) currentTimer + 1).ToString();
	}

	public void ShowTimer(float time) {
		gameObject.SetActive(true);
		this.currentTimer = time;
	}

	public void HideTimer() {
		gameObject.SetActive(false);
	}
}
