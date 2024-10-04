using UnityEngine;

namespace Model
{
    public class BulletModel
    {
        public Vector2 Position { get; set; }
        private static float Speed => 5f;

        public void Move(Vector2 forwardDirection)
        {
            Position += forwardDirection * (Speed * Time.deltaTime);
        }

        public BulletModel(Vector2 startPosition)
        {
            Position = startPosition;
        }
    }
}