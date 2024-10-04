using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class ShardController : MonoBehaviour, IControllerFolBorders
    {
        private ShardModel _shardModel;
        [SerializeField] private EnemyView _enemyView;

        private void Start()
        {
            //var speed = Random.Range(4f, 6f);
            _shardModel = new ShardModel(transform.position);
          //  GameController.Instance.GetGameModel()._shards.Add(_shardModel);
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
                Destroy(collision.gameObject);
                Destroy(gameObject);
                GameController.Instance.GetGameModel().AddScore(15);
            }
            
            if (collision.gameObject.CompareTag("Laser"))
            {
               // Destroy(collision.gameObject);
                Destroy(gameObject);
                GameController.Instance.GetGameModel().AddScore(15);
            }

            if (collision.gameObject.CompareTag("Ship"))
            {
                ShipController.Instance.OnCollision();
            }
        }
    }
}
