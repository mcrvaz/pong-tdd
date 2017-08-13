using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Pong_TDD.Assets.Scripts.Tests.Editor
{
    public class PlayerMovementTest
    {
        public class CalculateMovement {
            [Test]
            public void Moves_1_Unit_Vertically_With_1_Speed() {
                float speed = 1, y = 1, dt = 1;
                var pm = new PlayerMovement(speed);
                Assert.AreEqual(1, pm.CalculateMovement(y, dt).y, 0.1f);
            }

            [Test]
            public void Moves_1_Unit_Vertically_With_2_Speed() {
                float speed = 2, y = 1, dt = 1;
                var pm = new PlayerMovement(speed);
                Assert.AreEqual(2, pm.CalculateMovement(y, dt).y, 0.1f);
            }

            [Test]
            public void Moves_1_Unit_Vertically_With_1_Speed_And_Half_DeltaTime_() {
                float speed = 1, y = 1, dt = 0.5f;
                var pm = new PlayerMovement(speed);
                Assert.AreEqual(0.5f, pm.CalculateMovement(y, dt).y, 0.1f);
            }

            [Test]
            public void Horizontal_Position_Is_Zero() {
                float speed = 2, y = 1, dt = 1;
                var pm = new PlayerMovement(speed);
                Assert.AreEqual(0, pm.CalculateMovement(y, dt).x, 0.1f);
            }
        }
    }
}