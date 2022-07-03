using UnityEngine;


namespace Maze
{

    public class GoodBonus : Bonus, IFly, IFlick
    {
        private Material _material;

        private float _hightFly;
        

        private void Awake()
        {
            _material = GetComponent<Material>();
            _hightFly = Random.Range(1f, 3f);
        }

        private void Update()
        {
            Fly();
            Flick();
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _hightFly), transform.position.z);
        }

        public void Flick()
        {
            float alpha = Mathf.PingPong(Time.time, 1f);
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, alpha);
        }
    }
}