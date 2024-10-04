using Model;
using UnityEngine;
using View.Weapons;

namespace Controller
{
    public class BulletController: MonoBehaviour
    {
        private BulletModel _bulletModel;
        [SerializeField] private BulletView _bulletView;

        private Vector2 _direction;

        private void Awake()
        {
            _bulletModel = new BulletModel(transform.position);
        }
        
        private void OnEnable()
        {
            _bulletModel.PositionChanged += _bulletView.UpdatePosition;
            
            _bulletModel.Position = transform.position;
            _direction = ShipController.Instance.gameObject.transform.up;
        }

        private void OnDisable()
        {
            _bulletModel.PositionChanged -= _bulletView.UpdatePosition;
        }

        private void FixedUpdate()
        {
            _bulletModel.Move(_direction);
        }
    }
}