using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class ShardController : MonoBehaviour
    {
        private ShardModel _shardModel;
        [SerializeField] private EnemyView _enemyView;

        private void Start()
        {
            var speed = Random.Range(4f, 6f);
            _shardModel = new ShardModel(transform.position, speed);
            GameController.Instance.GetGameModel()._shards.Add(_shardModel);
        }

        private void Update()
        {
            _shardModel.Move();
            _enemyView.UpdatePosition(_shardModel.Position);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("Ship"))
            {
                ShipController.Instance.OnCollision();
            }
        }
    }
}
