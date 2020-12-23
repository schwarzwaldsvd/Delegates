using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    public class VideoEncoder
    {
        public VideoEncoder()
        {
        }

        // 1- Define a delegate
        // 2- Define an event based on that delegate
        // 3- Raise the event

        // old way .NET 2.0 -->
        // public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args); 
        // public event VideoEncodedEventHandler VideoEncoded;

        
        // in newer versions of .NET -->
        // EventHandler
        // EventHandler<TEventArgs>

        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video... ");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
            Console.ReadLine();
        }

        protected virtual void OnVideoEncoded(Video video) // Name: 'On'+<Name of the event>
        {
            VideoEncoded?.Invoke(this, new VideoEventArgs() { Video = video });
        }
    }
}