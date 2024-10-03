using System.Collections;
using UnityEngine;

namespace View
{
    public class ShipView : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private PoolView _poolView;

        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

        public void UpdateRotation(Quaternion newRotation)
        {
            transform.rotation = newRotation;
        }

        public void ShowBullet(Transform transformNew)
        {
            var shipHeight = transformNew.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y * transformNew.localScale;
            var newBulletPosition = transformNew.position;
            newBulletPosition = new Vector3(newBulletPosition.x, newBulletPosition.y + shipHeight.y, newBulletPosition.z);

            //var bullet = Instantiate(_bulletPrefab, newBulletPosition, Quaternion.identity);
            var bullet = _poolView.GetBulletPool().Get();
            bullet.SetActive(true);
            bullet.transform.position = newBulletPosition;
            bullet.transform.rotation = Quaternion.identity;

            bullet.transform.right = transformNew.up;
            
            StartCoroutine(ReturnObjectAfterDelay(bullet));
        }

        public void ShowLaser(Transform transformNew)
        {
            var shipHeight = transformNew.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y * transformNew.localScale;
            var halfLaserHeight = _laserPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x * _laserPrefab.transform.localScale/2;
            
            var newLaserPosition = transformNew.position;
           newLaserPosition = new Vector3(newLaserPosition.x, newLaserPosition.y + halfLaserHeight.x , newLaserPosition.z);
            
            
            var laser = Instantiate(_laserPrefab, newLaserPosition, Quaternion.identity);
            laser.transform.right = transformNew.up;
        }
        
        private IEnumerator ReturnObjectAfterDelay(GameObject objectToReturn)
        {
            yield return new WaitForSeconds(4f);
            
            _poolView.GetBulletPool().Release(objectToReturn);
        }
    }
}
