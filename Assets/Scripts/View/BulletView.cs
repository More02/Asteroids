using UnityEngine;

namespace View
{
    public class BulletView: MonoBehaviour
    {
        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

        public void UpdateRotation(Quaternion newRotation)
        {
            transform.rotation = newRotation;
        }
    }
}