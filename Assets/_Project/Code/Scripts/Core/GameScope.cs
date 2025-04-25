using Project.Code.Config;
using Project.Code.Game;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Code.Core
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private GameServiceConfig _gameServiceConfig;
        [SerializeField] private GamePresenterConfig _gamePresenterConfig;
        [SerializeField] private CameraServiceConfig _cameraServiceConfig;
        [SerializeField] private CharacterServiceConfig _characterServiceConfig;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameService>()
                .As<IGameService>()
                .WithParameter(_gameServiceConfig);
            
            builder.Register<CameraService>(Lifetime.Singleton)
                .As<ICameraService>()
                .WithParameter(_cameraServiceConfig);
            
            builder.Register<CharacterService>(Lifetime.Singleton)
                .As<ICharacterService>()
                .WithParameter(_characterServiceConfig);

            builder.Register<GamePresenter>(Lifetime.Singleton)
                .As<IGamePresenter>()
                .WithParameter(_gamePresenterConfig);

            builder.Register<GameModel>(Lifetime.Singleton)
                .As<IGameModel>();
        }
    }
}