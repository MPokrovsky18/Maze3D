using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Maze
{

    public class BadBonus : Bonus, IFly, IRotate
    {
        public event Action<string, Color> OnGameOver = delegate (string str, Color color) { };

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
            OnGameOver?.Invoke(gameObject.name, BonusColor);
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
