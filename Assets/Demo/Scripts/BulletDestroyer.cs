using System;
using UnityEngine;

namespace ObjectPool.Demo.Scripts
{
    public class BulletDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BulletPoolObject bullet))
            {
                ObjectPooler.Instance.ReturnToPool(bullet);
            }
        }
    }
}
