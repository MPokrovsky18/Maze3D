using UnityEngine;


namespace Maze
{

    public class Player : Unit
    {
        public override void Awake()
        {
            base.Awake();
        }

        public override void Move(float x, float y, float z)
        {
            if (_rigidbody)
            {
                _rigidbody.AddForce(new Vector3(x, y, z) * _speed);
            }
        }
    }
}
