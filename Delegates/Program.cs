using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {

        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply brightness");
        }

        public void ApplyConstrast(Photo photo)
        {
            Console.WriteLine("Apply contrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize photo");
        }
    }

    public class PhotoProcessor
    {
        //public delegate void PhotoFilterHandler(Photo photo);

        // Use generic delegate instead of custom
        //public void Process(string path)
        //public void Process(string path, PhotoFilterHandler filterHandler)
        public void Process(string path, Action<Photo> filterHandler)
        {
            
            var photo = Photo.Load(path);
            filterHandler(photo);



            //var filters = new PhotoFilters();
            //filters.ApplyBrightness(photo);
            //filters.ApplyConstrast(photo);
            //filters.Resize(photo);

            photo.Save();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var photoProcessor = new PhotoProcessor();
            var filters = new PhotoFilters();

            // Use generic delegate instead of custom
            //PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyConstrast;
            filterHandler += RemoveRedEyeFilter;


            //photoProcessor.Process("photo.jpg");
            photoProcessor.Process("photo.jpg", filterHandler);

        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply remove red eye");
        }
    }
}
