using UnityEngine;

namespace View
{
    public abstract class EnemyView : MonoBehaviour
    {
        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }
    }
}
