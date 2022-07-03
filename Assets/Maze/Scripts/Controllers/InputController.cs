using UnityEngine;


namespace Maze
{

    public class InputController
    {
        private readonly Unit _player;

        private const string STR_HORIZONTAL = "Horizontal";
        private const string STR_VERTICAL = "Vertical";

        private float horizontal;
        private float vertical;

        public InputController(Unit player)
        {
            if (player)
            {
                _player = player;
            }
        }

        public void Update()
        {
            GetInput();

            if (_player)
            {
                _player.Move(horizontal, 0f, vertical);
            }
        }

        private void GetInput()
        {
            horizontal = Input.GetAxis(STR_HORIZONTAL);
            vertical = Input.GetAxis(STR_VERTICAL);
        }
    }
}
