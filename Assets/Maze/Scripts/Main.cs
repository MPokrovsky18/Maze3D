using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{

    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        private CameraController _cameraController;
        private ListExecuteObject _executeObjects;
        private UIDisplayBonus _displayBonus;
        private UIDisplayGameOver _displayGameOver;

        [SerializeField] private Unit _player;
        [SerializeField] private Text _pointsLabel;
        [SerializeField] private Text _gameOverLabel;
        [SerializeField] private Button _restartButton;

        private int _bonusCount;

        private void Awake()
        {
            _executeObjects = new ListExecuteObject();
            _inputController = new InputController(_player);
            _cameraController = new CameraController(_player.transform, Camera.main.transform);
            _displayBonus = new UIDisplayBonus(_pointsLabel);
            _displayGameOver = new UIDisplayGameOver(_gameOverLabel);

            _executeObjects.AddExecuteObject(_inputController);
            _executeObjects.AddExecuteObject(_cameraController);
            _restartButton.onClick.AddListener(Restart);
            _restartButton.gameObject.SetActive(false);

            foreach(var item in _executeObjects)
            {
                if(item is GoodBonus goodBonus)
                {
                    goodBonus.AddPoints += AddPoint;
                }

                if(item is BadBonus badBonus)
                {
                    badBonus.OnGameOver += GameOver;
                    badBonus.OnGameOver += _displayGameOver.GameOver;
                }
            }
        }

        private void AddPoint(int value)
        {
            _bonusCount += value;
            _displayBonus.Display(_bonusCount);
        }

        private void GameOver(string value, Color color)
        {
            Time.timeScale = 0f;
            _restartButton.gameObject.SetActive(true);
        }

        private void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
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
