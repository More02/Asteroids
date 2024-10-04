using Model;
using Model.Enemy;
using UnityEngine;
using View;

namespace Controller.Enemy
{
    public class AsteroidController : MonoBehaviour, IControllerFolBorders
    {
        private AsteroidModel _asteroidModel;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private EnemySpawnerController _shardsSpawner;
        [SerializeField] private PoolView _poolView;

        private void Awake()
        {
            _asteroidModel = new AsteroidModel(transform.position);
            _asteroidModel.FillDirection();
        }

        private void OnEnable()
        {
            _asteroidModel.Position = transform.position;
            _asteroidModel.PositionChanged += _enemyView.UpdatePosition;
        }

        private void OnDisable()
        {
            _asteroidModel.PositionChanged -= _enemyView.UpdatePosition;
        }

        private void Update()
        {
            _asteroidModel.Move();
        }

        public IModelForBorder GetModel()
        {
            return _asteroidModel;
        }

        public IViewForBorder GetView()
        {
            return _enemyView;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                SpawnShard();
                ShipController.Instance.gameObject.GetComponent<PoolView>().GetPool().Release(collision.gameObject);
                _poolView.GetPool().Release(gameObject);
                GameController.Instance.GetGameModel().AddScore(10);
            }

            if (collision.gameObject.CompareTag("Laser"))
            {
                _poolView.GetPool().Release(gameObject);
                GameController.Instance.GetGameModel().AddScore(10);
            }
        }

        private void SpawnShard()
        {
            _shardsSpawner.SpawnEnemies();
        }
    }
}