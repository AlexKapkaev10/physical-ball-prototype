using Project.Code.Config;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

namespace Project.Code.Game
{
    public class GamePresenter : IGamePresenter
    {
        private readonly GamePresenterConfig _config;
        private readonly IGameModel _model;

        private IGameView view;

        public GamePresenter(IGameModel model, GamePresenterConfig config)
        {
            _model = model;
            _config = config;
        }

        public void Initialize()
        {
            view = Object.Instantiate(_config.GameViewPrefab, null);

            foreach (var buttonControl in view.ButtonsControl)
            {
                buttonControl.ControlClicked += OnButtonControlClick;
            }
        }

        public void Dispose()
        {
            foreach (var buttonControl in view.ButtonsControl)
            {
                buttonControl.ControlClicked -= OnButtonControlClick;
            }
        }

        private void OnButtonControlClick(ButtonControlType type, bool isPressed)
        {
            _model.ButtonControlClick(type, isPressed);
        }
    }
}