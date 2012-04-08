using System;

namespace Technics.Players
{
    internal class VideoPlayer : Player
    {
        public VideoPlayer()
        {
        }

        public VideoPlayer(string manufacturer, double? cost)
            : base(manufacturer, cost)
        {
        }

        public VideoPlayer(PlayList playList)
            : base(playList)
        {
        }

        public VideoPlayer(VideoClip videoClip)
            : base(videoClip)
        {
        }

        public override bool IsOn()
        {
            Console.WriteLine(base.IsOn() ? "VideoPlayer {0} is on" : "VideoPlayer {0} is off", ID);
            return base.IsOn();
        }

        public override void Play(PlayList playList)
        {
            Console.WriteLine("Play playlist");
            base.Play(playList);
        }

        public override void Play(VideoClip videoClip)
        {
            Console.WriteLine("Play videoclip");
            base.Play(videoClip);
        }
    }
}