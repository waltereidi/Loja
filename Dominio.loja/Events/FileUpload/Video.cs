﻿using Dominio.loja.Interfaces.Files;
using System.Text.Json.Serialization;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;

namespace Dominio.loja.Events.FileUpload
{
    public class Video : FileType , IFileTypeRestriction
    {
        public List<Dimensions> Dimensions { get; set; }
        public int MaxDurationInSeconds { get; set; }
        public int MinDurationInSeconds { get; set; }
        [JsonIgnore]
        public int DurationInSeconds { get; set; }

        public override string Type => throw new NotImplementedException();
        public Video(FileType ft) : base((string)ft)
        {
            DeserializeFileProperties();
        }
        public Video() { }
        public void IsValid(object ft)
        {
            Video video = (Video)ft;
            if (MinDurationInSeconds < DurationInSeconds)
                throw new ArgumentOutOfRangeException($"Minimun duration of video should be {MinDurationInSeconds} but  is {DurationInSeconds}");

            if (MaxDurationInSeconds > 0 && MaxDurationInSeconds < DurationInSeconds)
                throw new ArgumentOutOfRangeException($"Maximun allowed duration of video is {TimeSpan.FromSeconds(MaxDurationInSeconds).TotalMinutes} and the video have {TimeSpan.FromSeconds(DurationInSeconds).TotalMinutes} minutes");
        }
        public void GenerateEmptyRestriction()
        {
            Dimensions = new ();
            MaxDurationInSeconds = 0; 
            MinDurationInSeconds = 0;
        }

        public void SerializeFileProperties()
        {
            throw new NotImplementedException();
        }

        public void DeserializeFileProperties()
        {
            throw new NotImplementedException();
        }
    }
}
