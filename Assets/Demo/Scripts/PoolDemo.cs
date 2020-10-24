using System;
using UnityEngine;

namespace ObjectPool.Demo.Scripts
{
    public class PoolDemo : MonoBehaviour
    {
        [SerializeField] private float cameraSpeed = 1;

        [SerializeField] private float maxYawY = 45;
        [SerializeField] private float maxPitchX = 45;

        private float _ywaY;
        private float _pitchX;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                ObjectPooler.Instance.GetFromPool(PoolTagHelper.BulletTag, transform.position, transform.rotation, null);
        }

        private void LateUpdate()
        {
            _pitchX -= Input.GetAxis("Mouse Y") * cameraSpeed;
            _pitchX = Mathf.Clamp(_pitchX, -maxPitchX, maxPitchX);
            _ywaY += Input.GetAxis("Mouse X") * cameraSpeed;
            _ywaY = Mathf.Clamp(_ywaY, -maxYawY, maxYawY);
            
            transform.eulerAngles = new Vector3(_pitchX, _ywaY, 0f);
        }
    }
}