using System;

namespace Project.Code.Game
{
    public class GameModel : IGameModel
    {
        public event Action<ButtonControlType, bool> ControlClicked;
        
        public void ButtonControlClick(ButtonControlType type, bool isPressed)
        {
            ControlClicked?.Invoke(type, isPressed);
        }
    }
}