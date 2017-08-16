using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomProxy : IRandom {

    public float Value() {
        return Random.value;
    }

    public float Range(float min, float max) {
        return Random.Range(min, max);
    }

    public int Range(int min, int max) {
        return Random.Range(min, max);
    }

}
