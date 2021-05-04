using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Spotlight
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = Config.Load(Assembly.GetAssembly(typeof(Program)).CodeBase);

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string spotlightPath = Path.Combine(appData, @"\", @"Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets");

            if (!Directory.Exists(config.OutputDirectory))
                Directory.CreateDirectory(config.OutputDirectory);

            if(Directory.Exists(spotlightPath))
            {
                foreach (string file in Directory.GetFiles(spotlightPath))
                {
                    Image image = Image.FromFile(file);

                    if(image.Height >= config.MinHeight && image.Width >= config.MinWidth)
                    {
                        string destination = Path.Combine(config.OutputDirectory, Path.GetFileNameWithoutExtension(file));
                        
                        File.Copy(file, destination + ".jpg", true);
                    }
                }
            }
        }
    }
}
