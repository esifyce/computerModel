using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public interface IImageProcessor
    {
        void LoadImages(string path);
        void LoadKernel(string path);
        void SaveKernel(string path);
        void RunTests();
        void StartTraining();
        void AnalyzeImage(ref Bitmap image);
    }
}
