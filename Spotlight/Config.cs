using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotlight
{
    class Config
    {
        const string CONFIG_FILE_NAME = "spotlight.json";
        const int DEFAULT_MIN_HEIGHT = 1080;
        const int DEFAULT_MIN_WIDTH = 1920;
        private static string GetDefaultOutputDirectory()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                "SpotlightPictures");
        }

        private int _minHeight;
        private int _minWidth;
        private string _outputDirectory;
        private bool _loggingEnabled;

        public int MinHeight => _minHeight;
        public int MinWidth => _minWidth;
        public string OutputDirectory => _outputDirectory;
        public bool LoggingEnabled => _loggingEnabled;

        Config(
            int minHeight, 
            int minWidth, 
            string outputDirectory, 
            bool loggingEnabled
            )
        {
            _minHeight = minHeight;
            _minWidth = minWidth;
            _outputDirectory = outputDirectory;
            _loggingEnabled = loggingEnabled;
        }


        static Config Default
        {
            get
            {
                return new Config(
                    DEFAULT_MIN_HEIGHT,
                    DEFAULT_MIN_WIDTH,
                    GetDefaultOutputDirectory(),
                    true
                    );
            }
        }

        public static Config Load(string path)
        {
            var configFilePath = Path.Combine(path, CONFIG_FILE_NAME);

            if(File.Exists(configFilePath))
            {
                var configFile = File.ReadAllText(configFilePath);
                try
                {
                    Newtonsoft.Json.JsonConvert.DeserializeObject(configFile);
                } 
                catch 
                {
                    return Default;
                }
            }

            return Default;
        }
    }
}
