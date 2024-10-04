using System.Collections;
using Controller;
using UnityEngine;

namespace View
{
    public class ShipView : MonoBehaviour, IViewForBorder
    {
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
            var bullet = _poolView.GetPool().Get();
            bullet.SetActive(false);

            bullet.transform.position = transformNew.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.transform.right = transformNew.up;

            bullet.SetActive(true);
            StartCoroutine(ReturnObjectAfterDelay(bullet));
        }

        public void ShowLaser(Transform transformNew)
        {
            _laserPrefab.SetActive(true);
            StartCoroutine(HideObjectAfterDelay(_laserPrefab));
        }

        private IEnumerator ReturnObjectAfterDelay(GameObject objectToReturn)
        {
            yield return new WaitForSeconds(4f);

            _poolView.GetPool().Release(objectToReturn);
        }

        private static IEnumerator HideObjectAfterDelay(GameObject objectToHide)
        {
            yield return new WaitForSeconds(3f);

            objectToHide.SetActive(false);
            ShipController.Instance.IsLaserActive = false;
        }
    }
}