using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;

public class BasePlayTest {

	protected GameObject go;

	[TearDown]
	public void AfterEachTest() {
		GameObject.Destroy(go);
	}

}
