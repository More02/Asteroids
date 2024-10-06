using System.Collections;
using Controller;
using Model;
using UnityEngine;

namespace View.Weapons
{
    public class LaserView : MonoBehaviour
    {
        [SerializeField] private GameObject _laserObject;

        public void ShowLaser()
        {
            _laserObject.SetActive(true);
            StartCoroutine(HideObjectAfterDelay(_laserObject));
        }

        private static IEnumerator HideObjectAfterDelay(GameObject objectToHide)
        {
            yield return new WaitForSeconds(3f);

            objectToHide.SetActive(false);
            ShipController.Instance.IsLaserActive = false;

            if (((ShipModel)ShipController.Instance.GetModel()).LaserShotsLimit > 0)
            {
                ShipController.Instance.LaserButtonTips.GetComponent<CanvasGroup>().alpha = 1f;
            }

            ShipController.Instance.BulletButtonTips.GetComponent<CanvasGroup>().alpha = 1f;
        }

        public static IEnumerator RecoverLaserTimeForRecoverByTime()
        {
            var shipModel = (ShipModel)ShipController.Instance.GetModel();

            var timerToRecover = shipModel.TimeForLaserRecover;
            while (timerToRecover > 0)
            {
                GameView.Instance.UpdateTimeForLaserRecoverText(timerToRecover);
                yield return new WaitForSeconds(1f);
                timerToRecover--;
            }

            GameView.Instance.UpdateTimeForLaserRecoverText(shipModel.TimeForLaserRecover);
            if (((ShipModel)ShipController.Instance.GetModel()).LaserShotsLimit == 1)
                ShipController.Instance.LaserButtonTips.GetComponent<CanvasGroup>().alpha = 1f;
        }

        public static IEnumerator RecoverLaserLimitByTime()
        {
            var shipModel = (ShipModel)ShipController.Instance.GetModel();

            yield return new WaitForSeconds(shipModel.TimeForLaserRecover);

            shipModel.RecoverLaser();
            GameView.Instance.UpdateLaserShotsLimitText(shipModel.LaserShotsLimit);

            if (((ShipModel)ShipController.Instance.GetModel()).LaserShotsLimit == 1)
                ShipController.Instance.LaserButtonTips.GetComponent<CanvasGroup>().alpha = 1f;
        }
    }
}