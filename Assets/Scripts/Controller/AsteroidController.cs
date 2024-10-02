using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class AsteroidController : MonoBehaviour
    {
        [SerializeField] private AsteroidModel _asteroidModel;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private GameController _gameController;
        [SerializeField] private ShipController _shipController;
        [SerializeField] private EnemySpawnerController _enemySpawnerController;
        [SerializeField] private GameObject _shardsSpawnerHolder;
     

        private void Start()
        {
            var speed = Random.Range(1f, 3f);
            _asteroidModel = new AsteroidModel(transform.position, speed);
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
                Destroy(gameObject);
                _gameController._gameModel.AddScore(10);
            }

            if (collision.gameObject.CompareTag("Laser"))
            {
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("Ship"))
            {
                _shipController.OnCollision();
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
