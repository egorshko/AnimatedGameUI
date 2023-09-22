using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    internal class UiSequence
    {
        public ButtonColor Track;
        public List<Sprite> Sprites = new List<Sprite>();
    }
}
