using UnityEngine;


namespace Maze
{

    public class BadBonus : Bonus, IFly, IRotate
    {
        private float _speedRotate;

        protected override void Awake()
        {
            base.Awake();
            _speedRotate = Random.Range(13f, 40f);
        }

        public override void Update()
        {
            Fly();
            Rotate();
        }

        protected override void Interaction()
        {

        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, HeightFly), transform.position.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotate), Space.World);
        }
    }
}
