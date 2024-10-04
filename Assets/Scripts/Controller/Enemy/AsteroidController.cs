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
        [SerializeField] private GameObject _shardsSpawnerHolder;
        [SerializeField] private PoolView _poolView;

        private void Start()
        {
            _asteroidModel = new AsteroidModel(transform.position);
            _asteroidModel.FillDirection();
        }

        private void Update()
        {
            _asteroidModel.Move();
            _enemyView.UpdatePosition(_asteroidModel.Position);
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

            if (collision.gameObject.CompareTag("Ship"))
            {
                ShipController.OnCollision();
            }
        }

        private void SpawnShard()
        {
            _shardsSpawnerHolder.SetActive(true);
        }
    }
}