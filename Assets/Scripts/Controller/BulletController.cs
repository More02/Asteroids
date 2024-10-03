using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class BulletController: MonoBehaviour
    {
        private BulletModel _bulletModel;
        [SerializeField] private BulletView _bulletView;

        private Vector2 _direction;

        private void Start()
        {
            _bulletModel = new BulletModel(transform.position);
            _direction = ShipController.Instance.gameObject.transform.up;
        }

        private void FixedUpdate()
        {
            _bulletModel.Move(_direction);
            _bulletView.UpdatePosition(_bulletModel.Position);
        }
    }
}