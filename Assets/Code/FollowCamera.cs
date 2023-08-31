using UnityEngine;

namespace Code
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _speed;
        
        private Transform _transform;

        private void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            if (_target == null) return;
            
            _transform.position = Vector3.Lerp(_transform.position, _target.position + _offset, _speed * Time.deltaTime);
        }

        public void Follow(Transform target)
        {
            _target = target;
        }
    }
}