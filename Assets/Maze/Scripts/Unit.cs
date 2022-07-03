using UnityEngine;


namespace Maze
{

    public abstract class Unit : MonoBehaviour
    {
        protected Transform _transform;
        protected Rigidbody _rigidbody;

        [SerializeField] protected float _speed = 5f;
        protected int _health = 100;
        protected bool _isDead;

        public virtual void Awake()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public abstract void Move(float x, float y, float z);
    }
}
