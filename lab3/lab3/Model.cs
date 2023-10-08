using lab3.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.IO;


namespace lab3
{
    public class Model: IModel
    {
        private List<double[]> objectDescriptors = new List<double[]>();
        private List<double[]> backgroundDescriptors = new List<double[]>();

        public SupportVectorMachine<Accord.Statistics.Kernels.Linear> SVM;

        public void Train(IAnalyser analyzer, IImageDataProvider images)
        {
            Bitmap currentImage;
            Location currentLocation;
            var teacher = new SequentialMinimalOptimization<Accord.Statistics.Kernels.Linear>()
            {
                Complexity = 100
            };

            while ((currentImage = images.GetNextImage(out currentLocation)) != null)
            {
                analyzer = analyzer.GetAnalyser(ref currentImage);
                objectDescriptors.Add(analyzer.GetDescriptors(currentLocation));

                for (int i = 0; i < currentImage.Width - 79; i += 20)
                {
                    if (i > currentLocation.x0 - 20 && i < currentLocation.x1 + 20) continue;
                    backgroundDescriptors.Add(analyzer.GetDescriptors(new Location { x0 = i, y0 = 0 }));
                }
            }

            List<bool> output = new List<bool>(objectDescriptors.Count + backgroundDescriptors.Count);
            for (int i = 0; i < output.Capacity; i++)
            {
                if (i < objectDescriptors.Count) output.Add(true);
                else output.Add(false);
            }

            objectDescriptors.AddRange(backgroundDescriptors);
            SVM = teacher.Learn(objectDescriptors.ToArray(), output.ToArray());
        }

        public double[] Test(IAnalyser analyzer, IImageDataProvider images)
        {
            if (SVM == null) throw new Exception("Please train or load the SVM model before running tests.");

            Bitmap currentImage;
            Location currentLocation;
            List<Location> detectedLocations;
            double[] result = new double[2];
            double truePositives = 0, truePositivesTotal = 0, detectionsTotal = 0, tmp = 0;
            currentImage = images.GetNextImage(out currentLocation);
            if (currentImage == null) throw new Exception("Please select a folder containing test images before running tests.");
            do
            {
                detectedLocations = DetectObjects(analyzer, ref currentImage);
                if ((tmp = detectedLocations.Count(s => Math.Abs(s.x0 - currentLocation.x0) < 40)) > 0) truePositives++;

                truePositivesTotal += tmp;
                detectionsTotal += detectedLocations.Count - tmp;
            } while ((currentImage = images.GetNextImage(out currentLocation)) != null);

            result[0] = Math.Round(truePositives / images.CurrentImageIndex * 100);
            result[1] = Math.Round(truePositivesTotal / detectionsTotal * 100);
            return result;
        }

        public List<Location> DetectObjects(IAnalyser analyzer, ref Bitmap image)
        {
            analyzer = analyzer.GetAnalyser(ref image);
            List<Location> detectedLocations = new List<Location>();
            Location window;
            window.FileName = "";
            window.y0 = 0;
            window.y1 = 200;
            for (int i = 0; i < image.Width - 80; i += 3)
            {
                window.x0 = i;
                window.x1 = i + 80;
                if (SVM.Decide(analyzer.GetDescriptors(window)))
                {
                    detectedLocations.Add(window);
                }
            }
            DrawWindows(ref image, detectedLocations);
            return detectedLocations;
        }

        private void DrawWindows(ref Bitmap forScan, List<Location> locList)
        {
            int i;
            foreach (var loc in locList)
            {
                for (i = loc.x0; i < loc.x1; i++)
                {
                    forScan.SetPixel(i, loc.y0, Color.Red);
                    forScan.SetPixel(i, loc.y1, Color.Red);
                }
                for (i = loc.y0; i < loc.y1; i++)
                {
                    forScan.SetPixel(loc.x0, i, Color.Red);
                    forScan.SetPixel(loc.x1, i, Color.Red);
                }
            }
        }

        public void SaveModel(string path)
        {
            Serializer.Save(SVM, path);
        }

        public void LoadModel(string path)
        {
            SVM = Serializer.Load<SupportVectorMachine<Accord.Statistics.Kernels.Linear>>(path);
        }
    }
}
