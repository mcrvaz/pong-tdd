using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupEffect : MonoBehaviour {

	public float effectDuration;

	public abstract IEnumerator ApplyEffect(Player player, bool autoRemove = true);
	public abstract void RemoveEffect(Player player);

}
