using UnityEngine;

namespace View
{
    public class BulletView: MonoBehaviour
    {
        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }
    }
}