using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupEffect : MonoBehaviour {

	public float inspectorEffectDuration;

	public float effectDuration  { get; private set; }
	public bool effectApplied { get; private set; }

	private Player playerHit;

	void Update() {
		if (effectApplied) effectDuration -= Time.deltaTime;
	}

	public void ApplyEffect(Player player) {
		_ApplyEffect(player);
		playerHit = player;
		effectDuration = inspectorEffectDuration;
		effectApplied = true;
	}

	public void RemoveEffect(Player player) {
		_RemoveEffect(player);
		effectDuration = 0;
	}

	public void RemoveEffect() {
		_RemoveEffect(playerHit);
		effectDuration = 0;
	}

	protected abstract void _ApplyEffect(Player player);

	protected abstract void _RemoveEffect(Player player);

}
