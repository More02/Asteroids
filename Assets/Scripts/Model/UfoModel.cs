using UnityEngine;

namespace Model
{
    public class UfoModel: IEnemy
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; }

        public void Move(Vector2 targetPosition)
        {
            var direction = (targetPosition - Position).normalized;
            Position += direction * Speed * Time.deltaTime;
        }

        public void Move()
        {
        }

        public void OnHit()
        {
       
        }

        public UfoModel(Vector2 startPosition, float speed)
        {
            Position = startPosition;
            Speed = speed;
        }
    }
}
