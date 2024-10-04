using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class UfoController : MonoBehaviour, IControllerFolBorders
    {
        private UfoModel _ufoModel;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private PoolView _poolView;

        private void Start()
        {
            //var speed = 2f;
            _ufoModel = new UfoModel(transform.position); 
            //GameController.Instance.GetGameModel()._ufos.Add(_ufoModel);
        }
        
        public IModelForBorder GetModel()
        {
            return _ufoModel;
        }

        public IViewForBorder GetView()
        {
            return _enemyView;
        }

        private void Update()
        {
            Vector2 targetPosition = ShipController.Instance.transform.position;
            _ufoModel.Move(targetPosition);
            _enemyView.UpdatePosition(_ufoModel.Position);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
               // Destroy(collision.gameObject);
                //Destroy(gameObject);
                ShipController.Instance.gameObject.GetComponent<PoolView>().GetPool().Release(collision.gameObject);
                _poolView.GetPool().Release(gameObject);
                GameController.Instance.GetGameModel().AddScore(20);
            }
            
            if (collision.gameObject.CompareTag("Laser"))
            {
                //Destroy(collision.gameObject);
                //Destroy(gameObject);
                _poolView.GetPool().Release(gameObject);
                GameController.Instance.GetGameModel().AddScore(20);
            }

            if (collision.gameObject.CompareTag("Ship"))
            {
                ShipController.Instance.OnCollision();
            }
        }
    }
}
