using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class UiAnimator : IExecute, ICleanUp
    {
        private sealed class Animation : IExecute
        {
            public ButtonColor Track;
            public List<Sprite> Sprites;
            public bool Loop;
            public float Speed = 10.0f;
            public float Counter = 0;
            public bool Sleep;

            public void Execute(float deltatime)
            {
                if (Sleep) return;

                Counter += deltatime * Speed;

                if (Loop)
                {
                    while (Counter > Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }

                }
                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count;
                    Sleep = true;
                }
            }
        }

        private UiAnimationConfig _config;
        private Dictionary<Image, Animation> _activeAnimation = new Dictionary<Image, Animation>();
        public UiAnimator(UiAnimationConfig config)
        {
            _config = config;
        }

        public void StartAnimation(Image image, ButtonColor track, bool loop, float speed)
        {
            if (_activeAnimation.TryGetValue(image, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Sleep = false;
                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _config.Sequences().Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimation.Add(image, new Animation()
                {
                    Track = track,
                    Sprites = _config.Sequences().Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    Speed = speed
                });
            }
        }
        
        public void Execute(float deltatime)
        {
            foreach (var animation in _activeAnimation)
            {
                animation.Value.Execute(deltatime);
                if (animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }
            }
        }
        
        public void CleanUp()
        {
            _activeAnimation.Clear();
        }
    }

    
}
