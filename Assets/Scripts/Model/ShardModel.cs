using UnityEngine;

namespace Model
{
    public class ShardModel : IEnemy
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; }

        public void Move(Vector2 targetPosition)
        {
            Position += new Vector2(Mathf.Cos(Time.time) * Speed, Mathf.Sin(Time.time) * Speed) * Time.deltaTime;
        }

        public void Move()
        {
            Position += new Vector2(Mathf.Cos(Time.time) * Speed, Mathf.Sin(Time.time) * Speed) * Time.deltaTime;
        }

        public void OnHit()
        {
        }
        
    
        public ShardModel(Vector2 startPosition, float speed)
        {
            Position = startPosition;
            Speed = speed;
        }
    }
}
