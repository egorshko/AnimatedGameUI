using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    internal class UiFactory
    {
        private readonly UiAnimationConfig _uiConfig;
        public UiFactory(UiAnimationConfig uiAnimationConfig) 
        {
            _uiConfig = uiAnimationConfig;
        }
        public Transform CreateCanvas()
        {
            GameObject newCanvas = new GameObject("Canvas");
            Canvas canvas = newCanvas.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            newCanvas.AddComponent<CanvasScaler>();
            newCanvas.AddComponent<GraphicRaycaster>();


            return newCanvas.GetComponent<Transform>();

        }

        public Button CreatePlayButton(Transform canvas)
        {
            //GameObject newButton = new GameObject("Play Button");

            //Button button = newButton.AddComponent<Button>();
            //newButton.transform.SetParent(canvas);

            ////Text buttonText = button.AddComponent<Text>();
            ////buttonText.text = "Play";
            ////buttonText.alignment = TextAnchor.MiddleCenter;

            //Image buttonImage = newButton.AddComponent<Image>();
            //button.image = 

            //return button;

            var buttonInstance = Object.Instantiate(_uiConfig.PlayButton, canvas);

            return buttonInstance.GetComponent<Button>();
        }

        public Button CreateSettingButton(Transform canvas) 
        {
            //GameObject newButton = new GameObject("Settings Button");

            //Button button = newButton.AddComponent<Button>();
            //newButton.transform.SetParent(canvas);

            ////Text buttonText = button.AddComponent<Text>();
            ////buttonText.text = "Settings";
            ////buttonText.alignment = TextAnchor.MiddleCenter;

            //newButton.AddComponent<Image>();

            //return button;

            var buttonInstance = Object.Instantiate(_uiConfig.SettingsButton, canvas);

            return buttonInstance.GetComponent<Button>();
        }

        public Button CreateQuitButton(Transform canvas)
        {
            //GameObject newButton = new GameObject("Quit Button");

            //Button button = newButton.AddComponent<Button>();
            //newButton.transform.SetParent(canvas);

            ////Text buttonText = button.AddComponent<Text>();
            ////buttonText.text = "Quit";
            ////buttonText.alignment = TextAnchor.MiddleCenter;

            //newButton.AddComponent<Image>();

            //return button;

            var buttonInstance = Object.Instantiate(_uiConfig.QuitButton, canvas);

            return buttonInstance.GetComponent<Button>();
        }
    }
}
