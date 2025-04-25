using System;

namespace Project.Code.Game
{
    public interface IGameModel
    {
        event Action<ButtonControlType, bool> ControlClicked;
        void ButtonControlClick(ButtonControlType type, bool isPressed);
    }
}