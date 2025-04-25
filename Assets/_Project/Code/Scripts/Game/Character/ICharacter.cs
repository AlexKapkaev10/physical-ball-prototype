using UnityEngine;

namespace Project.Code.Game
{
    public interface ICharacter
    {
        Rigidbody2D Rigidbody2D { get; }
        Transform MoveTransform { get; }
        Transform RotationTransform { get; }
    }
}