using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model
{
    [Serializable]
    public class AsteroidModel : IEnemy, IModelForBorder
    {
        public Vector2 Direction { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; } = 3f;

        public void OnHit()
        {
        }

        public void FillDirection()
        {
            Direction = Random.insideUnitCircle;
        }

        public void Move()
        {
            Position += Direction * (Time.deltaTime * Speed);

            //var randomAngle = Random.Range(0f, 2 * Mathf.PI);
            //Position += new Vector2(Mathf.Cos(randomAngle) * Speed, Mathf.Sin(randomAngle)* Speed) * Time.deltaTime;
        }

        public void BreakIntoFragments()
        {
        }
        
        public AsteroidModel(Vector2 startPosition)
        {
            Position = startPosition;
            //Speed = speed;
        }
    }
}
