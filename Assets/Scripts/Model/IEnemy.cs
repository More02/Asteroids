using UnityEngine;

namespace Model
{
    public interface IEnemy
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public void Move();
        public void OnHit();
    }
}
