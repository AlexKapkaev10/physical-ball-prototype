using Project.Code.Config;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Code.Game
{
    public class GameService : IGameService
    {
        private readonly IGamePresenter _gamePresenter;
        private readonly ICameraService _cameraService;
        private readonly ICharacterService _characterService;
        private readonly GameServiceConfig _config;

        private ILevel _currentLevel;

        public GameService(
            IGamePresenter gamePresenter, 
            ICameraService cameraService,
            ICharacterService characterService,
            GameServiceConfig config)
        {
            _gamePresenter = gamePresenter;
            _cameraService = cameraService;
            _characterService = characterService;
            _config = config;
        }

        public void Initialize()
        {
            Application.targetFrameRate = 60;
            
            _currentLevel = Object.Instantiate(_config.DemoLevelPrefab, null);

            _cameraService.Initialize();
            _gamePresenter.Initialize();
            
            _characterService.CreateCharacter(_currentLevel.Transform);
        }

        public void FixedTick()
        {
            _characterService.FixedTick();
        }

        public void LateTick()
        {
            _cameraService.LateTick();
        }

        public void Dispose()
        {
            _gamePresenter.Dispose();
            _characterService.Dispose();
        }
    }
}