using UnityEngine;

namespace Model
{
    public class ShipModel
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        
        public float Speed { get; set; }
        public float TurnSpeed { get; set; }
        public int LaserShotsLimit { get; set; }

        public ShipModel(Vector2 startPosition)
        {
            Position = startPosition;
            Rotation = 0;
            LaserShotsLimit = 4;
        }

        public void UseLaser()
        {
            if (LaserShotsLimit > 0)
            {
                LaserShotsLimit--;
            }
        }

        public void RefillLaser(int numberToIncrease)
        {
            LaserShotsLimit += numberToIncrease;
        }
    }
}
