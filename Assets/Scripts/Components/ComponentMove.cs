using UnityEngine;
using UnityEditor;

namespace Nastrong
{
    public class ComponentMove : Component
    {
        [Header("Velocity Camera")]
        public float Velocity;
        [Header("Position Mouse")]
        public Vector2 position;

        [Header("View")]
        public bool bottom = false;
        public bool top = false;
        public bool left = false;
        public bool right = false;

        public override int type() {
            return (int) Type.ComponentMove;
        }
    }
}