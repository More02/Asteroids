using System;
using System.Collections;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;
using View;

namespace Controller
{
    public class ShipController : MonoBehaviour, IControllerFolBorders
    {
        [SerializeField] private ShipModel _shipModel;
        [SerializeField] private ShipView _shipView;

        private GameModel _gameModel;
        private const float Thrust = 9.8f;
        private Vector2 _velocity;
        
        private Vector2 _lastPosition;
        private Vector2 _currentPosition;
        private float _distance;
        private float _instantaneousSpeed;

        public bool IsLaserActive { get; set; }

        public static ShipController Instance;
        public Vector2 ShipStartPosition { get; private set; }
        
        

        private void Awake()
        {
            Instance = this;
            _shipModel = new ShipModel(transform.position, transform.rotation);
            ShipStartPosition = transform.position;
            _lastPosition = ShipStartPosition;
        }

        public IModelForBorder GetModel()
        {
            return _shipModel;
        }
        
        public IViewForBorder GetView()
        {
            return _shipView;
        }

        private void Start()
        {
            
        }
        
        private void Update()
        {
            HandleMovement();
            CalculateInstantaneousSpeed();

            //Debug.Log(GameController.Instance.GetGameModel().IsKeyboardInputEnabled);
            if (!GameController.Instance.GetGameModel().IsKeyboardInputEnabled) return;
            if (IsLaserActive) return;
            
            if (Input.GetMouseButtonDown(0))
            {
                FireWithBullet();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                FireWithLaser();
            }
        }

        // public void OnPointerClick(PointerEventData eventData)
        // {
        //     Debug.Log(GameController.Instance.GetGameModel().IsKeyboardInputEnabled);
        //     
        //
        //     switch (eventData.button)
        //     {
        //         case PointerEventData.InputButton.Left:
        //             FireWithBullet();
        //             Debug.Log("FireWithBullet");
        //             break;
        //         case PointerEventData.InputButton.Right:
        //             FireWithLaser();
        //             Debug.Log("FireWithLaser");
        //             break;
        //     }
        // }

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
            GameView.Instance.UpdateRotationText(_shipModel.Rotation.eulerAngles.z);
        }

        private void CalculateInstantaneousSpeed()
        {
            _currentPosition = _shipModel.Position;
            _distance = Vector2.Distance(_lastPosition, _currentPosition);
            _instantaneousSpeed= _distance / Time.deltaTime;
            _lastPosition = _currentPosition;
            
            GameView.Instance.UpdateInstantaneousSpeedText(_instantaneousSpeed);
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
            IsLaserActive = true;
            GameView.Instance.UpdateLaserShotsLimitText(_shipModel.LaserShotsLimit);
            StartCoroutine(RecoverLaserByTime());
        }
        
        private IEnumerator RecoverLaserByTime()
        {
            yield return new WaitForSeconds(_shipModel.TimeForLaserRecover);
            
            _shipModel.RecoverLaser();
            GameView.Instance.UpdateLaserShotsLimitText(_shipModel.LaserShotsLimit);
            
            while (_shipModel.TimeForLaserRecover > 0)
            {
                GameView.Instance.UpdateTimeForLaserRecoverText(_shipModel.TimeForLaserRecover);
                yield return new WaitForSeconds(1f); 
                _shipModel.TimeForLaserRecover--; 
            }
            GameView.Instance.UpdateTimeForLaserRecoverText(_shipModel.TimeForLaserRecover);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if ((col.gameObject.CompareTag("Bullet")) || (col.gameObject.CompareTag("Laser"))) return;
            
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
