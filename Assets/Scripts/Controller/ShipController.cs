using Model;
using UnityEngine;
using View;
using View.Weapons;

namespace Controller
{
    public class ShipController : MonoBehaviour, IControllerFolBorders
    {
        [SerializeField] private ShipModel _shipModel;
        [SerializeField] private ShipView _shipView;
        
        [SerializeField] private LaserView _laserView;
        [SerializeField] private BulletShooterView _bulletShooterView;
        
        private const float Thrust = 9.8f;
        private Vector2 _velocity;

        private Vector2 _lastPosition;
        private Vector2 _currentPosition;
        private float _distance;
        private float _instantaneousSpeed;

        public GameObject LaserButtonTips;
        public GameObject BulletButtonTips;

        [SerializeField] public GameObject _explosionObject;

        public bool IsLaserActive { get; set; }

        public static ShipController Instance;

        private Vector2 ShipStartPosition { get; set; }

        private void Awake()
        {
            Instance = this;
            _shipModel = new ShipModel(transform.position, transform.rotation);
            ShipStartPosition = transform.position;
            _lastPosition = ShipStartPosition;
        }

        private void OnEnable()
        {
            _shipModel.PositionChanged += _shipView.UpdatePosition;
            _shipModel.RotationChanged += _shipView.UpdateRotation;
        }

        private void OnDisable()
        {
            _shipModel.PositionChanged -= _shipView.UpdatePosition;
            _shipModel.RotationChanged -= _shipView.UpdateRotation;
        }

        public IModelForBorder GetModel()
        {
            return _shipModel;
        }

        public IViewForBorder GetView()
        {
            return _shipView;
        }

        private void Update()
        {
            HandleMovement();
            CalculateInstantaneousSpeed();
            
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
            
            GameView.Instance.UpdateRotationText(_shipModel.Rotation.eulerAngles.z);
        }

        private void CalculateInstantaneousSpeed()
        {
            _currentPosition = _shipModel.Position;
            _distance = Vector2.Distance(_lastPosition, _currentPosition);
            _instantaneousSpeed = _distance / Time.deltaTime;
            _lastPosition = _currentPosition;

            _shipModel.InstantaneousSpeed = _instantaneousSpeed;
            GameView.Instance.UpdateInstantaneousSpeedText(_shipModel.InstantaneousSpeed);
        }

        private void FireWithBullet()
        {
            _bulletShooterView.ShowBullet(transform);
        }

        private void FireWithLaser()
        {
            if (_shipModel.LaserShotsLimit == 0) return;
            
            LaserButtonTips.GetComponent<CanvasGroup>().alpha = 0.1f;
            BulletButtonTips.GetComponent<CanvasGroup>().alpha = 0.1f;
            _shipModel.UseLaser();
            _laserView.ShowLaser();
            IsLaserActive = true;
            GameView.Instance.UpdateLaserShotsLimitText(_shipModel.LaserShotsLimit);
            StartCoroutine(LaserView.RecoverLaserByTime());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ((collision.gameObject.CompareTag("Bullet")) || (collision.gameObject.CompareTag("Laser"))) return;
            
            GameController.Instance.EndGame(collision.contacts[0].point);
        }
    }
}