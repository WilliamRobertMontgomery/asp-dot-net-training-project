namespace Technics.Players
{
    using System;

    public abstract class Player : Technic, IPlayable
    {
        protected Player() { }

        private PlayList _playList;
        private VideoClip _videoClip;

        protected Player(string manufacturer, double? cost)
            : base(manufacturer, cost)
        {
        }

        protected Player(PlayList playList)
        {
            _playList = playList;
        }

        protected Player(VideoClip videoClip)
        {
            _videoClip = videoClip;
        }

        public virtual void Play()
        {
            if (_playList != null)
            {
                Console.WriteLine("Let's play playlist");
                Play(_playList);
            }
            else if (_videoClip != null)
            {
                Play(_videoClip);
                Console.WriteLine("Let's play videoclip");
            }
        }

        public virtual void Play(PlayList playList)
        {
            CanPlay();
        }

        public virtual void Play(VideoClip videoClip)
        {
            CanPlay();
        }

        protected virtual void CanPlay()
        {
            if (IsOn())
            {
                Console.WriteLine("OK, let's play");
            }
            else
            {
                Console.WriteLine("Player {0} isn't enabled, switch to using.", ID);
            }
        }

        public virtual void Stop()
        {
            Console.WriteLine("I'M UNSTOPPUBLE!!!11");
        }
    }
}