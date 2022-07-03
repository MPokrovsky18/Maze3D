using UnityEngine;


namespace Maze
{

    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        [SerializeField] private Unit _player;

        private void Awake()
        {
            _inputController = new InputController(_player);
        }

        private void Update()
        {
            _inputController.Update();
        }
    }
}
