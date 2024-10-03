using UnityEngine;
using UnityEngine.Pool;

namespace View
{
    public class PoolView : MonoBehaviour
    {
        private ObjectPool<GameObject> _pool;
        [SerializeField] private Transform _objectsForPoolHolder;

        public ObjectPool<GameObject> GetBulletPool()
        {
            return _pool;
        }

       // public static BulletPoolView Instance;

        private void Awake()
        {
            //Instance = this;
            _pool = new ObjectPool<GameObject>(
                createFunc: () => new GameObject("Bullet"),
                actionOnGet: (obj) => obj.SetActive(true), 
                actionOnRelease: (obj) => obj.SetActive(false),
                actionOnDestroy: (obj) => Destroy(obj), 
                false, defaultCapacity: 20, maxSize: 20
                );
            ChildToPool();
        }

        private void ChildToPool()
        {
            for (var i = 0; i < _objectsForPoolHolder.childCount; i++)
            {
                _pool.Release(_objectsForPoolHolder.GetChild(i).gameObject);
            }
        }
    }
}