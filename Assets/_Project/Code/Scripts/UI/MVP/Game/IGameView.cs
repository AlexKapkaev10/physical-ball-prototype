using System.Collections.Generic;

namespace Project.Code.Game
{
    public interface IGameView
    {
        List<ButtonControl> ButtonsControl { get; }
    }
}