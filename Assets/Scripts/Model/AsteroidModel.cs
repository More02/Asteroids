using UnityEngine;

namespace Model
{
    public class AsteroidModel : IEnemy
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; }

        public void OnHit()
        {
        }

        public void Move()
        {
            Position += new Vector2(Mathf.Cos(Time.time) * Speed, Mathf.Sin(Time.time) * Speed) * Time.deltaTime;
        }

        public void BreakIntoFragments()
        {
        }
        
        public AsteroidModel(Vector2 startPosition, float speed)
        {
            Position = startPosition;
            Speed = speed;
        }
    }
}
