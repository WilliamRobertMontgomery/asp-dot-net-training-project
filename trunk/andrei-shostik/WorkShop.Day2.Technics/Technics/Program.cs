using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using Technics.Players;

namespace Technics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Player videoPlayer = new VideoPlayer("Sony", 150);

            Console.WriteLine(videoPlayer.ToString());
            videoPlayer.IsOn();
            videoPlayer.TurnOn();
            videoPlayer.TurnOn();
            videoPlayer.IsOn();
            videoPlayer.TurnOff();
            videoPlayer.TurnOff();

            videoPlayer.Play();
            videoPlayer.Play();
            videoPlayer.Stop();

            videoPlayer.TurnOn();
            videoPlayer.Play(new PlayList());
            videoPlayer.Stop();

            videoPlayer.Play(new VideoClip());

            Console.WriteLine(videoPlayer.GetHashCode());
            Console.WriteLine(new VideoPlayer().ToString());
            Console.WriteLine(new VideoPlayer("Grundic", 100).ToString());
        }
    }
}