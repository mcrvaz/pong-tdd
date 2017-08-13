using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProxy : IInputProxy {
    public float GetAxisRaw(string axisName) {
		return Input.GetAxisRaw(axisName);
    }
}
