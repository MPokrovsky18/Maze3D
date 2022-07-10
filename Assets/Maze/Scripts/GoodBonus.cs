using UnityEngine;


namespace Maze
{

    public class GoodBonus : Bonus, IFly, IFlick
    {
        private Material _material;

        protected override void Awake()
        {
            base.Awake();
            _material = BonusRenderer.material;
        }

        public override void Update()
        {
            Fly();
            Flick();
        }

        protected override void Interaction()
        {

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