using lab3.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class ImageDataProvider: IImageDataProvider
    {
        private string imagePath;
        public int CurrentImageIndex { get; private set; }
        private List<Location> locationsList;
        private StreamReader reader;

        public ImageDataProvider(string imagePath)
        {
            try
            {
                CurrentImageIndex = -1;
                this.imagePath = imagePath;
                Location tmpLocation = new Location();
                string[] tmpData;
                reader = new StreamReader(Path.Combine(imagePath, "locations.txt"));
                string[] dataLines = reader.ReadToEnd().Split('\n');
                locationsList = new List<Location>(dataLines.Length);

                for (int i = 0; i < dataLines.Length - 1; i++)
                {
                    tmpData = dataLines[i].Split('\t');
                    tmpLocation.FileName = tmpData[0] + ".png";
                    tmpLocation.y0 = int.Parse(tmpData[1]);
                    tmpLocation.x0 = int.Parse(tmpData[2]);
                    tmpLocation.y1 = int.Parse(tmpData[3]);
                    tmpLocation.x1 = int.Parse(tmpData[4]);

                    locationsList.Add(tmpLocation);
                }
            }
            finally
            {
                reader.Close();
            }
        }

        public Bitmap GetNextImage(out Location location)
        {
            if (CurrentImageIndex < locationsList.Count - 1)
            {
                CurrentImageIndex++;
                location = locationsList[CurrentImageIndex];
                return new Bitmap(Path.Combine(imagePath, locationsList[CurrentImageIndex].FileName));
            }
            location = new Location();
            return null;
        }
    }
}
