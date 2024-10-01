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

        private float _thrust = 9.8f;
        private float _drag = 0.1f;         
        private Vector2 _velocity;          

        private void Start()
        {
            _shipModel = new ShipModel(transform.position);
        }

        private void HandleMovement()
        {
            if (Input.GetKey(KeyCode.W))
            {
                var thrustForce = (Vector2)transform.up * _thrust * Time.deltaTime;
                _velocity += thrustForce; 
                _velocity = Vector2.ClampMagnitude(_velocity, _shipModel.Speed); 
                
                _shipModel.Position += _velocity * Time.deltaTime; 
            }
            else
            {
                _velocity *= (1f - _drag);
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
            
            transform.rotation = Quaternion.Euler(0, 0, _shipModel.Rotation);
            transform.position = _shipModel.Position;

            // if (Input.GetButtonDown("Fire1"))
            // {
            //     _shipView.FireBullet(transform.position, transform.rotation);
            // }
            //
            // if (Input.GetButtonDown("Fire2"))
            // {
            //     if (_shipModel.LaserShotsLimit > 0)
            //     {
            //         _shipModel.UseLaser();
            //         _shipView.FireLaser(transform.position, transform.rotation);
            //     }
            // }
            
            HandleBoundaries();
        }

        private void HandleBoundaries()
        {
            
        }
        
        public void OnCollision()
        {
            //GameModel.EndGame();
            //перенести OnHit? Добавить инвоки для ивентов из GameView
        }
    }
}
