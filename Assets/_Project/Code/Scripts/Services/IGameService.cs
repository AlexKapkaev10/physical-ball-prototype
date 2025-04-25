using System;
using VContainer.Unity;

namespace Project.Code.Game
{
    public interface IGameService : IInitializable, IFixedTickable, ILateTickable, IDisposable
    {
    }
}