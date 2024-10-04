using System;
using Model;
using Model.Enemy;
using UnityEngine;
using View;

namespace Controller.Enemy
{
    public class UfoController : MonoBehaviour, IControllerFolBorders
    {
        private UfoModel _ufoModel;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private PoolView _poolView;

        private void Awake()
        {
            _ufoModel = new UfoModel(transform.position);
        }

        private void OnEnable()
        {
            _ufoModel.Position = transform.position;
            _ufoModel.PositionChanged += _enemyView.UpdatePosition;
        }

        private void OnDisable()
        {
            _ufoModel.PositionChanged -= _enemyView.UpdatePosition;
        }

        private void Update()
        {
            Vector2 targetPosition = ShipController.Instance.transform.position;
            _ufoModel.Move(targetPosition);
        }
        
        public IModelForBorder GetModel()
        {
            return _ufoModel;
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
                GameController.Instance.GetGameModel().AddScore(20);
            }

            if (collision.gameObject.CompareTag("Laser"))
            {
                _poolView.GetPool().Release(gameObject);
                GameController.Instance.GetGameModel().AddScore(20);
            }
        }
    }
}