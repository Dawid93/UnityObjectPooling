using UnityEngine;

namespace ObjectPool.Demo.Scripts
{
    public class BulletPoolObject : BasePoolObject
    {
        [SerializeField] private float bulletForce;
        private Rigidbody _rigidbody;
        public override void OnCreate(string poolTag)
        {
            base.OnCreate(poolTag);
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void OnSpawn()
        {
            _rigidbody.AddForce(transform.forward * bulletForce);
        }

        public override void OnReturn()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
