using Project.Code.Game;
using UnityEngine;

namespace Project.Code.Config
{
    [CreateAssetMenu(fileName = nameof(GamePresenterConfig), menuName = "Config/MVP/GamePresenter")]
    public class GamePresenterConfig : ScriptableObject
    {
        [field: SerializeField] public GameView GameViewPrefab { get; private set; }
    }
}