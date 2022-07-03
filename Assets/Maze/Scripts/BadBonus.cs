using UnityEngine;


namespace Maze
{

    public class BadBonus : Bonus, IFly, IRotate
    {
        private float _hightFly;
        private float _speedRotate;

        private void Awake()
        {
            _hightFly = Random.Range(1f, 3f);
            _speedRotate = Random.Range(13f, 40f);
        }

        private void Update()
        {
            Fly();
            Rotate();
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _hightFly), transform.position.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotate), Space.World);
        }
    }
}
