using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGrow : PowerupEffect {

	public override IEnumerator ApplyEffect(Player player, bool autoRemove = true) {
		player.transform.localScale = new Vector2(
			player.transform.localScale.x,
			player.initialState.transform.localScale.y * 2
		);
		if (autoRemove) {
			yield return new WaitForSeconds(this.effectDuration);
			RemoveEffect(player);
		}
		yield return null;
	}

	public override void RemoveEffect(Player player) {
		player.transform.localScale = player.initialState.transform.localScale;
	}

}
