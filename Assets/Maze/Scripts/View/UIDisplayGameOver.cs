using UnityEngine;
using UnityEngine.UI;


namespace Maze
{

    public class UIDisplayGameOver
    {
        private Text _gameOverLabel;

        public UIDisplayGameOver(Text gameOverLabel)
        {
            _gameOverLabel = gameOverLabel;
            _gameOverLabel.text = string.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _gameOverLabel.color = color;
            _gameOverLabel.text = $"Game Over! Bonus name: {name}, Color: {color}";
        }
    }
}
