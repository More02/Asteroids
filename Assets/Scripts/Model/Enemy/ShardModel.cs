using UnityEngine;

namespace Model.Enemy
{
    public class ShardModel : IEnemy, IModelForBorder
    {
        public Vector2 Direction { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; } = 4f;

        public void FillDirection()
        {
            Direction = Random.insideUnitCircle;
        }

        public void Move()
        {
            Position += Direction * (Time.deltaTime * Speed);
        }

        public ShardModel(Vector2 startPosition)
        {
            Position = startPosition;
        }
    }
}