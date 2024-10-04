using Model;
using Model.Enemy;
using UnityEngine;
using View;

namespace Controller.Enemy
{
    public class ShardController : MonoBehaviour, IControllerFolBorders
    {
        private ShardModel _shardModel;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private PoolView _poolView;

        private void Start()
        {
            _shardModel = new ShardModel(transform.position);
            _shardModel.FillDirection();
        }

        private void Update()
        {
            _shardModel.Move();
            _enemyView.UpdatePosition(_shardModel.Position);
        }

        public IModelForBorder GetModel()
        {
            return _shardModel;
        }

        public IViewForBorder GetView()
        {
            return _enemyView;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                ShipController.Instance.gameObject.GetComponent<PoolView>().GetPool().Release(collision.gameObject);
                _poolView.GetPool().Release(gameObject);
                GameController.Instance.GetGameModel().AddScore(15);
            }

            if (collision.gameObject.CompareTag("Laser"))
            {
                _poolView.GetPool().Release(gameObject);
                GameController.Instance.GetGameModel().AddScore(15);
            }

            if (collision.gameObject.CompareTag("Ship"))
            {
                ShipController.OnCollision();
            }
        }
    }
}