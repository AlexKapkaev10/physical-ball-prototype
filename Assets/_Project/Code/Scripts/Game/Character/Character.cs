using UnityEngine;

namespace Project.Code.Game
{
    public class Character : MonoBehaviour, ICharacter
    {
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public Transform MoveTransform { get; private set; }
        [field: SerializeField] public Transform RotationTransform { get; private set; }
    }
}