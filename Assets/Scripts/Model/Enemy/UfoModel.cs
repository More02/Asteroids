using UnityEngine;

namespace Model.Enemy
{
    public class UfoModel : IEnemy, IModelForBorder
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; } = 1.5f;

        public void Move(Vector2 targetPosition)
        {
            var direction = (targetPosition - Position).normalized;
            Position += direction * Speed * Time.deltaTime;
        }

        public void Move()
        {
        }
        
        public UfoModel(Vector2 startPosition)
        {
            Position = startPosition;
        }
    }
}