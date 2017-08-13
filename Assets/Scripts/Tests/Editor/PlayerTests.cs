using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

namespace Pong_TDD.Assets.Scripts.Tests.Editor {
    public class PlayerTests {
        private float speed;
        private Player player;
        private Rigidbody2D rigidbody;

        [SetUp]
        public void BeforeEachTest() {
            this.speed = 2;
            var go = new GameObject();
            var rb = go.AddComponent<Rigidbody2D>();
            this.player = go.AddComponent<Player>();
            this.player.Construct(speed, rb);
        }

        // public class UpdateMethod : PlayerTests {
        //     [UnityTest]
        //     public IEnumerator Moves_Along_Y_Axis_For_Vertical_Input_Starting_At_0() {
        //         float y = 1;
        //         var inputProxy = Substitute.For<IInputProxy>();
        //         var timeProxy = Substitute.For<ITimeProxy>();
        //         inputProxy.GetAxisRaw("Vertical").Returns(y);
        //         timeProxy.GetDeltaTime().Returns(y);
        //         player.inputProxy = inputProxy;
        //         player.timeProxy = timeProxy;
        //         yield return null;
        //         Assert.AreEqual(y * this.speed, player.transform.position.y, 0.1f);
        //     }

        //     // public IEnumerator Moves_Along_Y_Axis_For_Vertical_Input_Starting_At_1() {
        //     //     yield return null;
        //     // }
        // }

        // public class MoveMethod : PlayerTests {
        //     [UnityTest]
        //     public IEnumerator _1_Y_Moves_Player_1_Unit_Times_Speed_Vertical_Starting_At_0() {
        //         float y = 1, dt = 1;
        //         player.Move(y, dt);
        //         yield return null;
        //         Assert.AreEqual(y * this.speed, player.GetComponent<Rigidbody2D>().position.y, 0.1f);
        //     }

        //     [UnityTest]
        //     public IEnumerator _1_Y_Moves_Player_1_Unit_Times_Speed_Vertical_Starting_At_1() {
        //         float y = 1, dt = 1;
        //         player.GetComponent<Rigidbody2D>().position = new Vector2(1, 1);
        //         player.Move(y, dt);
        //         yield return null;
        //         Assert.AreEqual(1 + y * this.speed, player.GetComponent<Rigidbody2D>().position.y, 0.1f);
        //     }

        //     [UnityTest]
        //     public IEnumerator _0_Y_Does_Not_Move_Player_Vertically() {
        //         float y = 0, dt = 1;
        //         player.Move(y, dt);
        //         yield return null;
        //         Assert.AreEqual(y * this.speed, player.GetComponent<Rigidbody2D>().position.y, 0.1f);
        //     }

        //     [UnityTest]
        //     public IEnumerator _Player_Does_Not_Move_Horizontally_Starting_At_0() {
        //         float y = 1, dt = 1;
        //         float initialX = player.GetComponent<Rigidbody2D>().position.x;
        //         player.Move(y, dt);
        //         yield return null;
        //         Assert.AreEqual(initialX, player.GetComponent<Rigidbody2D>().position.x, 0.1f);
        //     }

        //     [UnityTest]
        //     public IEnumerator _Player_Does_Not_Move_Horizontally_Starting_At_1() {
        //         float y = 1, dt = 1;
        //         player.transform.position = new Vector2(1, 1);
        //         float initialX = player.GetComponent<Rigidbody2D>().position.x;
        //         player.Move(y, dt);
        //         yield return null;
        //         Assert.AreEqual(initialX, player.GetComponent<Rigidbody2D>().position.x, 0.1f);
        //     }
        // }
    }
}