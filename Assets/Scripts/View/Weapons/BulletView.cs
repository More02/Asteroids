using UnityEngine;

namespace View.Weapons
{
    public class BulletView : MonoBehaviour
    {
        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }
    }
}