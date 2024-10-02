using System;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class ShipController : MonoBehaviour
    {
        [SerializeField] private ShipModel _shipModel;
        [SerializeField] private ShipView _shipView;

        private GameModel _gameModel;
        private const float Thrust = 9.8f;
        private Vector2 _velocity;

        public static ShipController Instance;
        public Vector2 ShipStartPosition { get; private set; }

        private void OnEnable()
        {
            Instance = this;
        }

        public ShipModel GetShipModel()
        {
            return _shipModel;
        }
        
        public ShipView GetShipView()
        {
            return _shipView;
        }

        private void Start()
        {
            _shipModel = new ShipModel(transform.position, transform.rotation);
            ShipStartPosition = transform.position;
        }
        
        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            if (vertical > 0.1)
            {
                var thrustForce = (Vector2)transform.up * (Thrust * Time.deltaTime);
                _velocity += thrustForce; 
                _velocity = Vector2.ClampMagnitude(_velocity, _shipModel.Speed);
            }
            
            _shipModel.Position += _velocity * Time.deltaTime;
            if (_velocity.magnitude > 0.01)
                _velocity -= _velocity * Time.deltaTime;
            else
                _velocity = Vector2.zero;
            
            
            if (horizontal != 0)
            {
                _shipModel.Rotation *= Quaternion.Euler(0f, 0f, _shipModel.TurnSpeed * -horizontal * Time.deltaTime);
            }

            _shipView.UpdatePosition(_shipModel.Position);
            _shipView.UpdateRotation(_shipModel.Rotation);
        }

        public void FireWithBullet()
        {
            _shipView.ShowBullet(transform);
        }

        public void FireWithLaser()
        {
            if (_shipModel.LaserShotsLimit <= 0) return;
            _shipModel.UseLaser();
            _shipView.ShowLaser(transform);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            OnCollision();
        }

        public void OnCollision()
        {
            //инвок OnHit
            //GameModel.EndGame();
            //перенести OnHit? Добавить инвоки для ивентов из GameView
            
            //HitEvent?.Invoke();
            GameController.Instance.EndGame();

        }
    }
}
