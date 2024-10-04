using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class ShipModel : IModelForBorder
    {
        public Vector2 Position { get; set; }
        public Quaternion Rotation { get; set; }

        public float Speed { get; set; } = 3;
        public float InstantaneousSpeed { get; set; }
        public float TurnSpeed { get; set; } = 200;
        public int LaserShotsLimit { get; set; } = 4;
        public int QuantityOfLaserShotsToRecoverByOneTime { get; set; } = 1;
        public int TimeForLaserRecover { get; set; } = 5;
        

        public ShipModel(Vector2 startPosition, Quaternion startRotation)
        {
            Position = startPosition;
            Rotation = startRotation;
            //LaserShotsLimit = 4;
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
