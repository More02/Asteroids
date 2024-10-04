using System.Collections;
using UnityEngine;
using View;

namespace Controller.Enemy
{
     public class EnemySpawnerController : MonoBehaviour
     {
          [SerializeField] private int _enemyQuantity;
          [SerializeField] private EnemyView _enemyView;
          [SerializeField] private bool _isForSecondStageObjects;

          private Camera _mainCamera;
          private Vector2 _screenBounds;

          private void Start()
          {
               _mainCamera = Camera.main;
               _screenBounds = _mainCamera!.ViewportToWorldPoint(new Vector3(1, 1, _mainCamera.transform.position.z));
               if (_isForSecondStageObjects) return;
               StartCoroutine(SpawnEnemiesRoutine(_isForSecondStageObjects));
          }

          public void SpawnEnemies()
          {
               StartCoroutine(SpawnEnemiesRoutine(_isForSecondStageObjects));
          }
          
          private IEnumerator SpawnEnemiesRoutine(bool isMinQuantityNeeded)
          {
               var shipHeight = ShipController.Instance.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y * ShipController.Instance.transform.localScale;
               if (isMinQuantityNeeded)
               {
                    SpawnMethod(isMinQuantityNeeded, shipHeight);
                    yield return null;
               }
               else
               {
                    while (true)
                    {
                         SpawnMethod(isMinQuantityNeeded, shipHeight);
                         yield return new WaitForSeconds(5f);
                    }
               }
          }

          private void SpawnMethod(bool isMinQuantityNeeded, Vector3 shipHeight)
          {
               _enemyQuantity = isMinQuantityNeeded ? Random.Range(2, 4) : Random.Range(3, 6);
               
               for (var i = 0; i < _enemyQuantity; i++)
               {
                    var xPosRand = Random.Range(-_screenBounds.x, _screenBounds.x);
                    var yPosRand = Random.Range(-_screenBounds.y + shipHeight.y*2, _screenBounds.y );
                    _enemyView.CreateEnemy(new Vector2(xPosRand, yPosRand), Quaternion.identity);
               }
          }
     }
}
