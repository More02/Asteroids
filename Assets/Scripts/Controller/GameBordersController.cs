using UnityEngine;

namespace Controller
{
    public class GameBordersController : MonoBehaviour
    {
        private Camera _mainCamera;
        private Vector2 _screenBounds;

        private IControllerFolBorders _iControllerFolBordersController;

        private void Start()
        {
            _mainCamera = Camera.main;
            _screenBounds = _mainCamera!.ViewportToWorldPoint(new Vector3(1, 1, _mainCamera.transform.position.z));
            _iControllerFolBordersController = gameObject.GetComponent<IControllerFolBorders>();
           
        }

        private void LateUpdate()
        {
            var playerPosition = transform.position;
            playerPosition = WrapPosition(playerPosition);
           // ShipController.Instance.GetShipModel().Position = playerPosition;
           // ShipController.Instance.GetShipView().UpdatePosition(ShipController.Instance.GetShipModel().Position);

          // Debug.Log(_iControllerFolBordersController.GetModel().Position);
          if (_iControllerFolBordersController.GetModel() is null) return;
          
          _iControllerFolBordersController.GetModel().Position = playerPosition;
           _iControllerFolBordersController.GetView()!.UpdatePosition(_iControllerFolBordersController.GetModel().Position);
        }

        private Vector2 WrapPosition(Vector2 position)
        {
            if (position.y > _screenBounds.y)
            {
                position.y = -_screenBounds.y;
            }
            else if (position.y < -_screenBounds.y)
            {
                position.y = _screenBounds.y;
            }

            if (position.x > _screenBounds.x)
            {
                position.x = -_screenBounds.x;
            }
            else if (position.x < -_screenBounds.x)
            {
                position.x = _screenBounds.x;
            }

            return position;
        }
    }
}