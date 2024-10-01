using UnityEngine;

namespace View
{
    public class ShipView : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _laserPrefab;

        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

        public void UpdateRotation(float newRotation)
        {
            transform.rotation = Quaternion.Euler(0, 0, newRotation);
        }

        public void FireBullet(Vector2 position, Quaternion rotation)
        {
            Instantiate(_bulletPrefab, position, rotation);
        }

        public void FireLaser(Vector2 position, Quaternion rotation)
        {
            Instantiate(_laserPrefab, position, rotation);
        }
    }
}
