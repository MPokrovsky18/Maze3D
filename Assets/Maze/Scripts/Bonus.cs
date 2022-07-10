using UnityEngine;


namespace Maze
{

    public abstract class Bonus : MonoBehaviour, IExecute
    {
        private const string PLAYER_TAG = "Player";

        private Renderer _renderer;
        private Collider _collider;

        private bool _isInteractable;
        private Color _color;
        private float _heightFly;

        protected bool IsInteractable
        {
            get => _isInteractable;
            set
            {
                _isInteractable = value;
                BonusRenderer.enabled = value;
                _collider.enabled = value;
            }
        }
        protected float HeightFly { get => _heightFly; set => _heightFly = value; }
        protected Renderer BonusRenderer { get => _renderer; set => _renderer = value; }

        protected virtual void Awake()
        {
            BonusRenderer = GetComponent<Renderer>();
            _collider = GetComponent<Collider>();
            IsInteractable = true;
            _color = Random.ColorHSV();
            BonusRenderer.sharedMaterial.color = _color;
            HeightFly = Random.Range(1f, 4f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(IsInteractable || other.CompareTag(PLAYER_TAG))
            {
                Interaction();
                IsInteractable = false;
            }
        }

        protected abstract void Interaction();

        public abstract void Update();
    }
}
