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

        private void Awake()
        {
            _shardModel = new ShardModel(transform.position);
            _shardModel.FillDirection();
        }

        private void OnEnable()
        {
            _shardModel.Position = transform.position;
            _shardModel.PositionChanged += _enemyView.UpdatePosition;
        }

        private void OnDisable()
        {
            _shardModel.PositionChanged -= _enemyView.UpdatePosition;
        }

        private void Update()
        {
            _shardModel.Move();
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
        }
    }
}