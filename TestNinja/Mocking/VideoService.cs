using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        //public IFileReader FileReader { get; set; }
        private IFileReader _fileReader;
        private IVideoRepository _repository;

        //In production code, this constructor will be used. 
        //public VideoService()
        //{
        //    _fileReader = new FileReader();
        //}
        ////In Testing code, this constructor will be used.
        //public VideoService(IFileReader fileReader)
        //{
        //    //_fileReader= new FileReader();
        //    _fileReader = fileReader;

        //}

        //Both constructors can be combined into one using.
        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
        {
            //_fileReader= new FileReader();
            _fileReader = fileReader ?? new FileReader(); //If fileReader is null, then make a new fileReader object. Otherwise, take the one already supplied via the parameters.
            _repository = repository ?? new VideoRepository();

        }
        public string ReadVideoTitle()
        {
            //var str = File.ReadAllText("video.txt");
            //var str = new FileReader().Read("video.txt");
            //Passing in an interface makes it loosely coupled.
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            var videos = _repository.GetUnprocessedVideos();
                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}