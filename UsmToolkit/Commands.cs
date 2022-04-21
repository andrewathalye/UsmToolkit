using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using VGMToolbox.format;

namespace UsmToolkit
{
    [Command(Description = "Extract audio and video")]
    public class ExtractCommand
    {
        [Required]
        [FileOrDirectoryExists]
        [Argument(0, Description = "File or folder containing usm files")]
        public string InputPath { get; set; }

        protected int OnExecute(CommandLineApplication app)
        {
            FileAttributes attr = File.GetAttributes(InputPath);
            if (attr.HasFlag(FileAttributes.Directory))
            {
                foreach (var file in Directory.GetFiles(InputPath, "*.usm"))
                    Process(file);
            }
            else
                Process(InputPath);

            return 0;
        }

        private void Process(string fileName)
        {
            Console.WriteLine($"File: {fileName}");
            var usmStream = new CriUsmStream(fileName);

            Console.WriteLine("Demuxing...");
            usmStream.DemultiplexStreams(new MpegStream.DemuxOptionsStruct()
            {
                AddHeader = false,
                AddPlaybackHacks = false,
                ExtractAudio = true,
                ExtractVideo = true,
                SplitAudioStreams = false
            });
        }
    }
    
}
