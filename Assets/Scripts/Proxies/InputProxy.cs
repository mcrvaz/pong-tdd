﻿using UnityEngine;

public class InputProxy : IInput {
    public float GetAxisRaw(string axisName) {
        return Input.GetAxisRaw(axisName);
    }
}
