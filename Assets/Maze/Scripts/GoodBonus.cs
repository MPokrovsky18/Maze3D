using System;
using UnityEngine;


namespace Maze
{

    public class GoodBonus : Bonus, IFly, IFlick
    {
        public event Action<int> AddPoints = delegate (int i) { };

        private Material _material;

        private int _point;

        protected override void Awake()
        {
            base.Awake();
            _material = BonusRenderer.material;
            _point = 1;
        }

        public override void Update()
        {
            Fly();
            Flick();
        }

        protected override void Interaction()
        {
            AddPoints?.Invoke(_point);
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, HeightFly), transform.position.z);
        }

        public void Flick()
        {
            float alpha = Mathf.PingPong(Time.time, 1f);
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, alpha);
        }
    }
}