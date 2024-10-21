using Dominio.loja.Interfaces.Files;
using System.Text.Json.Serialization;
using static Dominio.loja.Events.FileUpload.FileManagerEvents;

namespace Dominio.loja.Events.FileUpload
{
    public sealed class Video : FileType , IFileTypeRestriction , IFileTypeProperty
    {
        public override string Type => typeof(Video).Name;
        public List<FileProperties.Dimensions> Dimensions { get; set; }
        public int MaxDurationInSeconds { get; set; }
        public int MinDurationInSeconds { get; set; }
        public int DurationInSeconds { get; set; }

        public Video() { }
        public Video(FileType ft) : base(ft)
        {
            
        }
        public void IsValid(object ft, FileInfo fi)
        {
            Video video = (Video)ft;
            if (MinDurationInSeconds < DurationInSeconds)
                throw new ArgumentOutOfRangeException($"Minimun duration of video should be {MinDurationInSeconds} but  is {DurationInSeconds}");

            if (MaxDurationInSeconds > 0 && MaxDurationInSeconds < DurationInSeconds)
                throw new ArgumentOutOfRangeException($"Maximun allowed duration of video is {TimeSpan.FromSeconds(MaxDurationInSeconds).TotalMinutes} and the video have {TimeSpan.FromSeconds(DurationInSeconds).TotalMinutes} minutes");
        }

        public void SetFileProperty(object fp)
        {
            var video = (FileProperties.Video)fp;
            Dimensions.Add(video.dimensions);
            DurationInSeconds = video.durationInSeconds;
        }
    }
}
