using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSeggregationPrincipal
{

    public interface IAudioPlayer
    {
        void PlayAudio(string fileName);
    }


    public interface IVideoPlayer
    {
        void PlayVideo(string fileName, string resolution);
    }

    public class IPod : IAudioPlayer
    {
        public void PlayAudio(string fileName)
        {
            Console.WriteLine($"Playing audio file: {fileName}");
        }
    }

    public class TV : IAudioPlayer, IVideoPlayer
    {
        public void PlayAudio(string fileName)
        {
            Console.WriteLine($"Playing audio file: {fileName}");
        }

        public void PlayVideo(string fileName, string resolution)
        {
            Console.WriteLine($"Playing video file: {fileName} at {resolution} resolution");
        }
    }

}