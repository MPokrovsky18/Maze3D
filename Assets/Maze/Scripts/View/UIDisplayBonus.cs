using UnityEngine;
using UnityEngine.UI;


namespace Maze
{

    public class UIDisplayBonus
    {
        private Text _pointsLabel;

        public UIDisplayBonus(Text pointsLabel)
        {
            _pointsLabel = pointsLabel;
            _pointsLabel.text = "Points: 0";
        }

        public void Display(int value)
        {
            _pointsLabel.text = $"Points: {value}";
        }
    }
}

