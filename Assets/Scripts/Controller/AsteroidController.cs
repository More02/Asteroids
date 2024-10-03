using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class AsteroidController : MonoBehaviour
    {
        private AsteroidModel _asteroidModel;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private GameObject _shardsSpawnerHolder;
        [SerializeField] private PoolView _poolView;

        private void Start()
        {
           // var speed = Random.Range(1f, 3f);
            _asteroidModel = new AsteroidModel(transform.position);
            
            GameController.Instance.GetGameModel()._asteroids.Add(_asteroidModel);
            
            _asteroidModel.FillDirection();
        }

        private void Update()
        {
            _asteroidModel.Move();
            _enemyView.UpdatePosition(_asteroidModel.Position);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                SpawnShard();
                //Destroy(gameObject);
                _poolView.GetBulletPool().Release(gameObject);
                GameController.Instance.GetGameModel().AddScore(10);
            }

            if (collision.gameObject.CompareTag("Laser"))
            {
                //Destroy(collision.gameObject);
                //Destroy(gameObject);
                _poolView.GetBulletPool().Release(gameObject);
                GameController.Instance.GetGameModel().AddScore(10);
            }

            if (collision.gameObject.CompareTag("Ship"))
            {
                ShipController.Instance.OnCollision();
            }
        }

        private void SpawnShard()
        {
            //вызвать что-то из ShardController вместо всего этого метода?
            //сначала инстанциация, потом уже создание объекта модели в старте ShardController
            var shardsSpawnerHolder = Instantiate(_shardsSpawnerHolder, _asteroidModel.Position, transform.rotation);
            //shardsSpawnerHolder.GetComponent<EnemyController>()
           // var shardPosition = _asteroidModel.Position; 
            //var shardSpeed = Random.Range(4f, 6f);
           // var shard = new ShardModel(shardPosition, shardSpeed);
            // Создание ShardView или префаба
        }
    }
}
