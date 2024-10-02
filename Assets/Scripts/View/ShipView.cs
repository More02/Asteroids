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

        public void UpdateRotation(Quaternion newRotation)
        {
            transform.rotation = newRotation;
        }

        public void ShowBullet(Transform position)
        {
            var pref = Instantiate(_bulletPrefab, position.position, Quaternion.identity);
            pref.transform.right = position.up;
        }

        public void ShowLaser(Transform position)
        {
            var pref = Instantiate(_laserPrefab, position.position, Quaternion.identity);
            pref.transform.right = position.up;
        }
    }
}
