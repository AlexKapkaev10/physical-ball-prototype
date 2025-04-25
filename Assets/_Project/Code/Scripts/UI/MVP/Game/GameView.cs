using System.Collections.Generic;
using UnityEngine;

namespace Project.Code.Game
{
    public class GameView : MonoBehaviour, IGameView
    {
        [field: SerializeField] public List<ButtonControl> ButtonsControl { get; private set; }
    }
}