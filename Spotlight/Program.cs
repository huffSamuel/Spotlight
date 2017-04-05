using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotlight
{
    class Program
    {
        static void Main(string[] args)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string myPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string spotlightPath = Path.Combine(appData + @"\", @"Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets");
            string spotlightDestinationPath = Path.Combine(myPictures, "SpotlightPictures");

            if (!Directory.Exists(spotlightDestinationPath))
                Directory.CreateDirectory(spotlightDestinationPath);

            if(Directory.Exists(spotlightPath))
            {
                foreach (string file in Directory.GetFiles(spotlightPath))
                {
                    Image image = Image.FromFile(file);

                    if(image.Height >= 1080 && image.Width >= 1920)
                    {
                        string destination = Path.Combine(myPictures, "SpotlightPictures", Path.GetFileNameWithoutExtension(file));
                        
                        File.Copy(file, destination + ".jpg");
                    }
                }
            }
        }
    }
}
