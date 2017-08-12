using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public void Move(float input) {
		this.transform.position = new Vector2(this.transform.position.x, input);
	}

}
