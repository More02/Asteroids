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
               
               StartCoroutine(SpawnEnemiesRoutine(_isForSecondStageObjects, Vector3.zero));
          }

          public void SpawnEnemies(Vector3 targetPosition)
          {
               StartCoroutine(SpawnEnemiesRoutine(_isForSecondStageObjects, targetPosition));
          }
          
          private IEnumerator SpawnEnemiesRoutine(bool isForSecondStageObjects, Vector3 targetPosition)
          {
               var shipHeight = ShipController.Instance.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y * ShipController.Instance.transform.localScale;
               if (isForSecondStageObjects)
               {
                    SpawnMethod(isForSecondStageObjects, shipHeight, targetPosition);
                    yield return null;
               }
               else
               {
                    while (true)
                    {
                         SpawnMethod(isForSecondStageObjects, shipHeight, Vector3.zero);
                         yield return new WaitForSeconds(5f);
                    }
               }
          }

          private void SpawnMethod(bool isForSecondStageObjects, Vector3 shipHeight, Vector3 targetPosition)
          {
               _enemyQuantity = isForSecondStageObjects ? Random.Range(2, 4) : Random.Range(3, 6);

               for (var i = 0; i < _enemyQuantity; i++)
               {
                    float xPosRand;
                    float yPosRand;
                    
                    if (isForSecondStageObjects)
                    {
                         xPosRand = targetPosition.x + Random.Range(-2, 2);
                         yPosRand = targetPosition.y + Random.Range(-2, 2);
                    }
                    else
                    {
                         xPosRand = Random.Range(-_screenBounds.x, _screenBounds.x);
                         yPosRand = Random.Range(-_screenBounds.y + shipHeight.y*2, _screenBounds.y );
                    }
                    
                    _enemyView.CreateEnemy(new Vector2(xPosRand, yPosRand), Quaternion.identity);
               }
          }
     }
}
