using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class UfoController : MonoBehaviour
    {
        private UfoModel _ufoModel;
        [SerializeField] private EnemyView _enemyView;

        private void Start()
        {
            _ufoModel = new UfoModel(transform.position, 2f); 
            GameController.Instance.GetGameModel()._ufos.Add(_ufoModel);
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
                Destroy(collision.gameObject);
                Destroy(gameObject);
                GameController.Instance.GetGameModel().AddScore(20);
            }

            if (collision.gameObject.CompareTag("Ship"))
            {
                ShipController.Instance.OnCollision();
            }
        }
    }
}
