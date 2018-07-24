using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGrow : PowerupEffect {

	protected override void _ApplyEffect(Player player) {
		player.transform.localScale = new Vector2(
			player.transform.localScale.x,
			player.initialState.transform.localScale.y * 2
		);
	}

	protected override void _RemoveEffect(Player player) {
		player.transform.localScale = player.initialState.transform.localScale;
	}

}
