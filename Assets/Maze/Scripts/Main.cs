using UnityEngine;


namespace Maze
{

    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        private CameraController _cameraController;
        private ListExecuteObject _executeObjects;
        [SerializeField] private Unit _player;

        private void Awake()
        {
            _executeObjects = new ListExecuteObject();
            _inputController = new InputController(_player);
            _cameraController = new CameraController(_player.transform, Camera.main.transform);
            _executeObjects.AddExecuteObject(_inputController);
            _executeObjects.AddExecuteObject(_cameraController);
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
