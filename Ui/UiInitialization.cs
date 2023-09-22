using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class UiInitialization
    {
        private readonly UiFactory _factory;

        private Transform _canvas;

        private Button _playButton;
        private Button _settingsButton;
        private Button _quitButton;

        public UiInitialization(UiFactory uiFactory) 
        {
            _factory = uiFactory;

            _canvas = _factory.CreateCanvas();
            _playButton = _factory.CreatePlayButton(_canvas);
            _settingsButton = _factory.CreateSettingButton(_canvas);
            _quitButton = _factory.CreateQuitButton(_canvas);
        }

        public Image GetPlayButton()
        {
            return _playButton.GetComponent<Image>();   
        }

        public Image GetSettingsButton() 
        {
            return _settingsButton.GetComponent<Image>();
        }

        public Image GetQuitButton()
        {
            return _quitButton.GetComponent<Image>();
        }
    }
}
