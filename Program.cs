// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Linq;

namespace someNameSpace
{
    //delegate void CustomEventHadler();
    class CustomEventArgs : EventArgs
    {
        public String? Email { get; set; }
    }
    

    class VideoEncoder
    {
        public event Func<int>? VideoEncoded;

        public void OnEncoded(string email)
        {
            Console.WriteLine("Video Encoded");

            VideoEncoded?.Invoke();

        }
    }


    class Instagram
    {
        public static int Send()
        {
            Console.WriteLine($"Uploaded a video to Instagram for  user");
            return 0;
        }
    }

    class Snap
    {
        public static int Send()
        {
            Console.WriteLine($"Uploaded a video to Instagram for  user");
            return 0;
        }
    }

    class Program
    {
        /*public static void Main(string[] args)
        {
            

        }*/
    }
}