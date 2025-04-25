using System;
using UnityEngine;
using VContainer.Unity;

namespace Project.Code.Game
{
    public interface ICharacterService : IFixedTickable, IDisposable
    {
        event Action<ICharacter> CharacterCreated;
        void CreateCharacter(Transform parent = null);
    }
}