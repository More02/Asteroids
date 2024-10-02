using System.Collections.Generic;
using UnityEngine;
using View;

namespace Controller
{
     // public enum ModelType
     // {
     //      Asteroid,
     //      Ufo,
     //      Shard
     // }
     public class EnemySpawnerController : MonoBehaviour
     {
          [SerializeField] private int _asteroidQuantity;
          [SerializeField] private EnemyView _enemyView;
          [SerializeField] private bool _isMinQuantityNeeded;

          [SerializeField] private List<GameObject> _shardsList;
         // [SerializeField] private ModelType _modelType;
          
          private Camera _mainCamera;
          private Vector2 _screenBounds;

          private void OnEnable()
          {
               _mainCamera = Camera.main;
               _screenBounds = _mainCamera!.ViewportToWorldPoint(new Vector3(1, 1, _mainCamera.transform.position.z));
               SpawnEnemies(_isMinQuantityNeeded);
          }

          private void SpawnEnemies(bool isMinQuantityNeeded)
          {
               _asteroidQuantity = isMinQuantityNeeded ? Random.Range(2, 4) : Random.Range(4, 7);
               
               for (var i = 0; i < _asteroidQuantity; i++)
               {
                    if (_shardsList.Count != 0)
                    {
                         var randomShard = Random.Range(0, _shardsList.Count);
                         _enemyView.SetEnemyPrefab(_shardsList[randomShard]);
                    }
                    var xPosRand = Random.Range(-_screenBounds.x, _screenBounds.x);
                    var yPosRand = Random.Range(-_screenBounds.y, _screenBounds.y);
                    _enemyView.CreateEnemy(new Vector2(xPosRand, yPosRand), Quaternion.identity);
               }
          }
     }
}
