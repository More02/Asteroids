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
        
        [SerializeField] private GameModel _gameModel;
        [SerializeField] private GameController _gameController;

        private const float Thrust = 9.8f;
        private const float Drag = 0.1f;
        public Vector2 ShipStartPosition { get; private set; }
        private Vector2 _velocity;

        private void Start()
        {
            _shipModel = new ShipModel(transform.position);
            ShipStartPosition = transform.position;
        }
        
        private void Update()
        {
            HandleMovement();
            _shipView.UpdatePosition(_shipModel.Position);
            _shipView.UpdateRotation(_shipModel.Rotation);
        }

        private void HandleMovement()
        {
            if (Input.GetKey(KeyCode.W))
            {
                var thrustForce = (Vector2)transform.up * (Thrust * Time.deltaTime);
                _velocity += thrustForce; 
                _velocity = Vector2.ClampMagnitude(_velocity, _shipModel.Speed); 
                
                _shipModel.Position += _velocity * Time.deltaTime; 
            }
            else
            {
                _velocity *= (1f - Drag);
                _shipModel.Position += _velocity * Time.deltaTime; 
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                _shipModel.Rotation += _shipModel.TurnSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                _shipModel.Rotation -= _shipModel.TurnSpeed * Time.deltaTime;
            }

            Transform transformVar;
            (transformVar = transform).rotation = Quaternion.Euler(0, 0, _shipModel.Rotation);
            transformVar.position = _shipModel.Position;
        }

        public void FireWithBullet()
        {
            var transform1 = transform;
            _shipView.FireBullet(transform1.position, transform1.rotation);
        }

        public void FireWithLaser()
        {
            if (_shipModel.LaserShotsLimit > 0)
            {
                var transformVar = transform;
                _shipModel.UseLaser();
                _shipView.FireLaser(transformVar.position, transformVar.rotation);
            }
        }

        public void OnCollision()
        {
            //инвок OnHit
            //GameModel.EndGame();
            //перенести OnHit? Добавить инвоки для ивентов из GameView
            
            //HitEvent?.Invoke();
            _gameController.EndGame();

        }
    }
}
