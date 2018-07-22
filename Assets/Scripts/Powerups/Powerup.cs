using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	public float speed;

	private PowerupEffect pwEffect;
	private Vector2 direction;

	void Awake() {
		this.pwEffect = GetComponent<PowerupEffect>();
	}

	void Start() {
		List<Vector2> directions = new List<Vector2>{ Vector2.right, Vector2.left };
		direction = directions[Random.Range(0, directions.Count)];
	}

	void FixedUpdate () {
		transform.Translate(direction * Time.fixedDeltaTime * speed);
	}

	void OnCollisionEnter2D(Collision2D col) {
		var colGo = col.gameObject;
		if (colGo.CompareTag(Tags.PLAYER)) {
			Player player = colGo.GetComponent<Player>();
			StartCoroutine(ApplyEffect(player));
		}
	}

	IEnumerator ApplyEffect(Player player) {
		GetComponent<SpriteRenderer>().enabled = false;
		yield return pwEffect.ApplyEffect(player);
		Destroy(gameObject);
	}

}
