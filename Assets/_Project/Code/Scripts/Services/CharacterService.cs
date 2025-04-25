using System;
using Project.Code.Config;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Code.Game
{
    public class CharacterService : ICharacterService
    {
        private readonly IGameModel _gameModel;
        private readonly CharacterServiceConfig _config;
        private ICharacter _character;
        private Rigidbody2D _rigidbody;
        
        private float _maxSpeed;
        private bool isMovingLeft;
        private bool isMovingRight;

        public event Action<ICharacter> CharacterCreated;

        public CharacterService(IGameModel gameModel, CharacterServiceConfig config)
        {
            _gameModel = gameModel;
            _config = config;
            
            _maxSpeed = _config.MaxSpeed;
        }

        private void OnControlClicked(ButtonControlType type, bool isPressed)
        {
            switch (type)
            {
                case ButtonControlType.Left:
                    isMovingLeft = isPressed;
                    if (isMovingLeft && _rigidbody.linearVelocity.x > -_maxSpeed)
                    {
                        _rigidbody.linearVelocity = new Vector2(0, _rigidbody.linearVelocity.y);
                        _rigidbody.AddForce(Vector2.left * _config.MoveForce, ForceMode2D.Impulse);
                    }
                    break;
                case ButtonControlType.Right:
                    isMovingRight = isPressed;
                    if (isMovingRight && _rigidbody.linearVelocity.x < _maxSpeed)
                    {
                        _rigidbody.linearVelocity = new Vector2(0, _rigidbody.linearVelocity.y);
                        _rigidbody.AddForce(Vector2.right * _config.MoveForce, ForceMode2D.Impulse);
                    }
                    break;
                case ButtonControlType.Jump:
                    if (isPressed)
                    {
                        _rigidbody.AddForce(Vector2.up * _config.JumpForce, ForceMode2D.Impulse);
                    }
                    break;
            }
        }

        public void CreateCharacter(Transform parent = null)
        {
            _gameModel.ControlClicked += OnControlClicked;
            
            _character = Object.Instantiate(_config.CharacterPrefab, parent);
            _rigidbody = _character.Rigidbody2D;
            CharacterCreated?.Invoke(_character);
        }

        public void FixedTick()
        {
            if (isMovingLeft)
            {
                if (_rigidbody.linearVelocity.x > -_maxSpeed)
                {
                    _rigidbody.AddForce(Vector2.left * _config.MoveForce);
                }
            }
            else if (isMovingRight)
            {
                if (_rigidbody.linearVelocity.x < _maxSpeed)
                {
                    _rigidbody.AddForce(Vector2.right * _config.MoveForce);
                }
            }
            else if (Mathf.Abs(_rigidbody.linearVelocity.x) > 0.1f)
            {
                _rigidbody.AddForce(new Vector2(-_rigidbody.linearVelocity.x * _config.BrakeForce, 0));
            }
            /*else
            {
                _rigidbody.linearVelocity = Vector2.zero;
            }*/
        }

        public void Dispose()
        {
            _gameModel.ControlClicked -= OnControlClicked;
        }
    }
}