using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PowerupEffect))]
public class Powerup : MonoBehaviour {

	public float speed;

	private PowerupEffect pwEffect;
	private Vector2 direction;

	void Awake() {
		this.pwEffect = GetComponent<PowerupEffect>();
	}

	void Start() {
		direction = new Vector2(new RandomUtils().Opposite(1), 0);
	}

	void Update() {
		if (pwEffect.effectApplied && pwEffect.effectDuration <= 0) pwEffect.RemoveEffect();
	}

	void FixedUpdate () {
		transform.Translate(direction * Time.fixedDeltaTime * speed);
	}

	void OnCollisionEnter2D(Collision2D col) {
		var colGo = col.gameObject;
		if (colGo.CompareTag(Tags.PLAYER)) {
			ApplyEffect(colGo.GetComponent<Player>());
		}
	}

	void ApplyEffect(Player player) {
		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<BoxCollider2D>().enabled = false;
		pwEffect.ApplyEffect(player);
	}

}
