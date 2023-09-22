using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class UiController : IController, IExecute, ICleanUp
    {
        private UiAnimator _uiAnimator;
        private UiAnimationConfig _uiAnimationConfig;
        private UiInitialization _uiInitialization;

        private Image _playButton;
        private Image _settingsButton;
        private Image _quitButton;

        public UiController(UiAnimationConfig uiAnimationConfig, UiInitialization uiInitialization) 
        {
            _uiAnimationConfig = uiAnimationConfig;
            _uiInitialization = uiInitialization;

            _playButton = _uiInitialization.GetPlayButton();
            _settingsButton = _uiInitialization.GetSettingsButton();
            _quitButton = _uiInitialization.GetQuitButton();

            _uiAnimator = new UiAnimator(_uiAnimationConfig);

            _uiAnimator.StartAnimation(_playButton, ButtonColor.White, true, 5.5f);
            _uiAnimator.StartAnimation(_settingsButton, ButtonColor.Purple, true, 4.5f);
            _uiAnimator.StartAnimation(_quitButton, ButtonColor.Pink, true, 3.5f);
        }

        public void Execute(float deltatime)
        {
            _uiAnimator.Execute(deltatime);
        }

        public void CleanUp()
        {
            _uiAnimator.CleanUp();
        }
    }
}
