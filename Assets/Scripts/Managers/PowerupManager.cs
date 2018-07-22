using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

	public float minTimeBetweenPowerup;
	public float maxTimeBetweenPowerup;
	public List<GameObject> powerUps;
	[HideInInspector]
	public bool pauseGeneration;

	private float upperBoundVerticalPosition;
	private float lowerBoundVerticalPosition;

	private float timeToSpawn;
	private const float SPAWN_MARGIN = 0.5f;

	void Awake() {
		var upperBound = GameObject.FindGameObjectWithTag(Tags.UPPER_BOUND);
		var lowerBound = GameObject.FindGameObjectWithTag(Tags.LOWER_BOUND);
		var upperBoundVerticalSize = upperBound.GetComponent<BoxCollider2D>().bounds.extents.y;
		var lowerBoundVerticalSize = lowerBound.GetComponent<BoxCollider2D>().bounds.extents.y;
		upperBoundVerticalPosition = upperBound.transform.position.y - (upperBoundVerticalSize);
		lowerBoundVerticalPosition = lowerBound.transform.position.y + (lowerBoundVerticalSize);
	}

	void Start() {
		timeToSpawn = Random.Range(minTimeBetweenPowerup, maxTimeBetweenPowerup);
	}

	void Update() {
		if (pauseGeneration) return;

		timeToSpawn -= Time.deltaTime;
		if (timeToSpawn <= 0) {
			SpawnPowerup(powerUps[Random.Range(0, powerUps.Count - 1)]);
			timeToSpawn = Random.Range(minTimeBetweenPowerup, maxTimeBetweenPowerup);
		}
	}

	GameObject SpawnPowerup(GameObject pw) {
		float y = Random.Range(
			upperBoundVerticalPosition - SPAWN_MARGIN,
			lowerBoundVerticalPosition + SPAWN_MARGIN
		);
		Vector2 position = new Vector2(transform.position.x, y);
		return GameObject.Instantiate(pw, position, Quaternion.identity);
	}

	public void PauseGeneration() {
		this.pauseGeneration = true;
	}

	public void ResumeGeneration() {
		this.pauseGeneration = false;
	}

}
