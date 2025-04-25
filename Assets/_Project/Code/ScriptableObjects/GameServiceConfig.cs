using Project.Code.Game;
using UnityEngine;

namespace Project.Code.Config
{
    [CreateAssetMenu(fileName = nameof(GameServiceConfig), menuName = "Config/Service/Game")]
    public class GameServiceConfig : ScriptableObject
    {
        [field: SerializeField] public Level DemoLevelPrefab { get; private set; }
    }
}