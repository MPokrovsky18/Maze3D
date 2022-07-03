using UnityEngine;


namespace Maze
{

    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        private ListExecuteObject _executeObjects;
        [SerializeField] private Unit _player;

        private void Awake()
        {
            _executeObjects = new ListExecuteObject();
            _inputController = new InputController(_player);
            _executeObjects.AddExecuteObject(_inputController);
        }

        private void Update()
        {
            for(int i = 0; i < _executeObjects.Lenght; i++)
            {
                if (_executeObjects[i] == null)
                {
                    continue;
                }

                _executeObjects[i].Update();
            }
        }
    }
}
