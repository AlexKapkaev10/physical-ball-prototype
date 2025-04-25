using System;
using Project.Code.Config;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Code.Game
{
    public class CameraService : ICameraService
    {
        private readonly ICharacterService _characterService;
        private readonly CameraServiceConfig _config;

        private Transform _targetTransform;
        private Transform _cameraTransform;

        public CameraService(ICharacterService characterService, CameraServiceConfig config)
        {
            _characterService = characterService;
            _config = config;
        }

        public void Initialize()
        {
            _characterService.CharacterCreated += OnCharacterCreated;
            
            _cameraTransform = Object.Instantiate(_config.CameraPrefab)
                .GetComponent<Transform>();
            
            _cameraTransform.position = _config.CameraOffset;
        }

        public void LateTick()
        {
            if (!_targetTransform)
            {
                return;
            }
            
            var desiredPosition = _targetTransform.position + _config.CameraOffset;
            var smoothedPosition = Vector3.Lerp(_cameraTransform.position, desiredPosition, _config.SmoothSpeed);
            smoothedPosition.y = _cameraTransform.position.y;
            _cameraTransform.position = smoothedPosition;
        }

        private void OnCharacterCreated(ICharacter character)
        {
            _characterService.CharacterCreated -= OnCharacterCreated;
            _targetTransform = character.MoveTransform;
        }
    }
}