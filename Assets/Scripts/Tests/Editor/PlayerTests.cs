using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerTests {

    public class MoveMethod {
        [UnityTest]
        public IEnumerator _1_Sets_Player_Position_To_1_Y_And_Same_X() {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            var currentX = player.transform.position.x;

            player.Move(1);

            yield return null;

            Assert.AreEqual(1, player.transform.position.y, 0.1f);
            Assert.AreEqual(currentX, player.transform.position.x, 0.1f);
        }

        [UnityTest]
        public IEnumerator _Minus_1_Sets_Player_Position_To_Minus_1_Y_And_Same_X() {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            var currentX = player.transform.position.x;

            player.Move(-1);

            yield return null;

            Assert.AreEqual(-1, player.transform.position.y, 0.1f);
            Assert.AreEqual(currentX, player.transform.position.x, 0.1f);
        }
    }
}
