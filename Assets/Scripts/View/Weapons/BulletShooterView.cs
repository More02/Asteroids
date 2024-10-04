using System.Collections;
using Controller;
using UnityEngine;

namespace View.Weapons
{
    public class BulletShooterView : MonoBehaviour
    {
        [SerializeField] private PoolView _poolView;

        public void ShowBullet(Transform transformNew)
        {
            if (_poolView.GetPool().CountInactive > 0)
            {
                var bullet = _poolView.GetPool().Get();
                bullet.SetActive(false);

                bullet.transform.position = transformNew.position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.transform.right = transformNew.up;

                bullet.SetActive(true);
                StartCoroutine(ReturnObjectAfterDelay(bullet));
            }
            else
            {
                ShipController.Instance.BulletButtonTips.GetComponent<CanvasGroup>().alpha = 0.1f;
            }
        }

        private IEnumerator ReturnObjectAfterDelay(GameObject objectToReturn)
        {
            yield return new WaitForSeconds(4f);

            ShipController.Instance.BulletButtonTips.GetComponent<CanvasGroup>().alpha = 1f;
            _poolView.GetPool().Release(objectToReturn);
        }
    }
}