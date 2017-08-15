using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Pong_TDD.Assets.Scripts.Tests.Editor
{
    public class PlayerMovementTest
    {
        public class CalculateMovement {

            private float speed;
            private PlayerMovement pm;
            private Vector2 currentPosition;

            [SetUp]
            public void BeforeEachTest() {
                this.speed = 2;
                this.pm = new PlayerMovement(speed);
                this.currentPosition = Vector2.zero;
            }

            [Test]
            public void Moves_Y_Times_Speed_Units_Vertically_Starting_At_0() {
                float y = 1, dt = 1;
                Assert.AreEqual(y * speed, pm.CalculateMovement(currentPosition, y, dt).y, 0.1f);
            }

            [Test]
            public void Moves_Y_Times_Speed_Units_Vertically_Starting_At_1() {
                float y = 1, dt = 1;
                this.currentPosition = Vector2.one;
                Assert.AreEqual(y * speed + 1, pm.CalculateMovement(currentPosition, y, dt).y, 0.1f);
            }

            [Test]
            public void Moves_Y_Times_Speed_Units_Vertically_With_Half_DeltaTime() {
                float y = 1, dt = 0.5f;
                Assert.AreEqual(y * speed * dt, pm.CalculateMovement(currentPosition, y, dt).y, 0.1f);
            }

            [Test]
            public void Horizontal_Position_Is_Unchanged() {
                float y = 1, dt = 1;
                Assert.AreEqual(0, pm.CalculateMovement(currentPosition, y, dt).x, 0.1f);
            }
        }
    }
}