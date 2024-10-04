using System;
using UnityEngine;

namespace Model.Enemy
{
    [Serializable]
    public class UfoModel : IEnemy, IModelForBorder
    {
        public event Action<Vector2> PositionChanged;

        private Vector2 _position;
        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke(Position);
            }
        }
        public float Speed { get; set; } = 1.5f;

        public void Move(Vector2 targetPosition)
        {
            var direction = (targetPosition - Position).normalized;
            Position += direction * (Speed * Time.deltaTime);
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