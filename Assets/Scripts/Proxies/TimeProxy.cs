using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeProxy : ITimeProxy {
    public float GetDeltaTime() {
		  return Time.deltaTime;
    }

    public float GetFixedDeltaTime() {
      return Time.fixedDeltaTime;
    }
}
