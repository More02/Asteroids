using UnityEngine;

namespace Model
{
    public class BulletModel
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; } = 5f;

        public void OnHit()
        {
        }

        public void Move(Vector2 forwardDirection)
        {
            Position += forwardDirection * (Speed * Time.deltaTime);;
        }
        
        public BulletModel(Vector2 startPosition)
        {
            Position = startPosition;
            //Speed = speed;
        }
    }
}