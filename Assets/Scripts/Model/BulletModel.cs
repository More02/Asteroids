using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class BulletModel
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