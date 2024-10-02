using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class UfoController : MonoBehaviour
    {
        [SerializeField] private UfoModel _ufoModel;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private GameController _gameController;
        [SerializeField] private Transform _shipTransform; 
        [SerializeField] private ShipController _shipController;

        private void Start()
        {
            _ufoModel = new UfoModel(transform.position, 2f); 
        }

        private void Update()
        {
            Vector2 targetPosition = _shipTransform.position;
            _ufoModel.Move(targetPosition);
            _enemyView.UpdatePosition(_ufoModel.Position);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                _gameController._gameModel.AddScore(20);
            }

            if (collision.gameObject.CompareTag("Ship"))
            {
                _shipController.OnCollision();
            }
        }
    }
}
