using Accord.IO;
using Accord.Math;
using lab3.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public class ImageProcessor: IImageProcessor
    {
        private IImageDataProvider loadedImageList = null;
        private IModel currentModel = null;
        private IForm currentView = null;

        public ImageProcessor(IModel model, IForm view)
        {
            currentModel = model;
            currentView = view;
        }

        public void LoadImages(string path)
        {
            try
            {
                loadedImageList = new ImageDataProvider(path);
                currentView.DisplayMessage("Images loaded successfully.");
            }
            catch (Exception ex)
            {
                currentView.DisplayMessage("Error loading images: " + ex.Message);
            }
        }

        public void LoadKernel(string path)
        {
            try
            {
                currentModel.LoadModel(path);
                currentView.DisplayMessage("Kernel loaded successfully.");
            }
            catch (Exception ex)
            {
                currentView.DisplayMessage("Error loading kernel: " + ex.Message);
            }
        }

        public void SaveKernel(string path)
        {
            try
            {
                currentModel.SaveModel(path);
                currentView.DisplayMessage("Kernel saved successfully.");
            }
            catch (Exception ex)
            {
                currentView.DisplayMessage("Error saving kernel: " + ex.Message);
            }
        }

        public void RunTests()
        {
            double[] results = new double[2];
            if (loadedImageList == null)
            {
                currentView.DisplayMessage("No folder selected containing test images.");
            }
            else
            {
                results = currentModel.Test(new Analyser(), loadedImageList);
                currentView.DisplayMessage("Test results: Response = " + results[0] + "%. Accuracy = " + results[1] + "%.");
            }
        }

        public void StartTraining()
        {
            if (loadedImageList == null)
            {
                currentView.DisplayMessage("No folder selected containing training images.");
            }
            else
            {
                currentModel.Train(new Analyser(), loadedImageList);
                currentView.DisplayMessage("Training completed.");
            }
        }

        public void AnalyzeImage(ref Bitmap image)
        {
            List<Location> locationList = currentModel.DetectObjects(new Analyser(), ref image);
            currentView.DisplayImage(image);
        }
    }
}
