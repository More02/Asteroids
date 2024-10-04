using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class ShipModel : IModelForBorder
    {
        public event Action<Vector2> PositionChanged;
        public event Action<Quaternion> RotationChanged;

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

        private Quaternion _rotation;

        public Quaternion Rotation
        {
            get => _rotation;

            set
            {
                _rotation = value;
                RotationChanged?.Invoke(Rotation);
            }
        }

        public float Speed { get; set; } = 3;
        public float InstantaneousSpeed { get; set; }
        public float TurnSpeed { get; set; } = 200;
        public int LaserShotsLimit { get; set; } = 4;
        public int QuantityOfLaserShotsToRecoverByOneTime { get; set; } = 1;
        public int TimeForLaserRecover { get; set; } = 8;

        public ShipModel(Vector2 startPosition, Quaternion startRotation)
        {
            Position = startPosition;
            Rotation = startRotation;
        }

        public void UseLaser()
        {
            if (LaserShotsLimit > 0)
            {
                LaserShotsLimit--;
            }
        }

        public void RecoverLaser()
        {
            LaserShotsLimit += QuantityOfLaserShotsToRecoverByOneTime;
        }

        public void RefillLaser(int numberToIncrease)
        {
            LaserShotsLimit += numberToIncrease;
        }
    }
}