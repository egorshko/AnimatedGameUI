using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [CreateAssetMenu (fileName = nameof(UiAnimationConfig), menuName = "Configs")]
    internal class UiAnimationConfig : ScriptableObject
    {
        [SerializeField] List<UiSequence> _sequences = new List<UiSequence>();

        public List<UiSequence> Sequences()
        {
            return _sequences;
        }

        [SerializeField] private GameObject _playButton;
        [SerializeField] private GameObject _settingsButton;
        [SerializeField] private GameObject _quitButton;

        public GameObject PlayButton => _playButton;
        public GameObject SettingsButton => _settingsButton;
        public GameObject QuitButton => _quitButton;

         
    }
}
