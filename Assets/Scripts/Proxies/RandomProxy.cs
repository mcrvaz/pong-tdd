using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomProxy : IRandom {
    public float Value() {
        return Random.value;
    }
}
