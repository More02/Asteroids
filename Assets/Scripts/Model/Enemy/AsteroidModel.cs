using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.Enemy
{
    [Serializable]
    public class AsteroidModel : IEnemy, IModelForBorder
    {
        public Vector2 Direction { get; set; }

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

        public float Speed { get; set; } = 3f;

        public void FillDirection()
        {
            Direction = Random.insideUnitCircle;
        }

        public void Move()
        {
            Position += Direction * (Time.deltaTime * Speed);
        }

        public AsteroidModel(Vector2 startPosition)
        {
            Position = startPosition;
        }
    }
}