using Project.Code.Game;
using UnityEngine;

namespace Project.Code.Config
{
    [CreateAssetMenu(fileName = nameof(CharacterServiceConfig), menuName = "Config/Service/Character")]
    public class CharacterServiceConfig : ScriptableObject
    {
        [field: SerializeField] public Character CharacterPrefab { get; private set; }
        
        [field: SerializeField] public float MoveForce { get; private set; } = 10f;
        [field: SerializeField] public float MaxSpeed { get; private set; } = 20f;
        [field: SerializeField] public float BrakeForce { get; private set; } = 2f;
        [field: SerializeField] public float JumpForce { get; private set; } = 2f;
    }
}