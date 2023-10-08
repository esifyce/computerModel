using lab3.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorMine.ColorSpaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab3
{
    public class Analyser: IAnalyser
    {
        private double[,,] PxlGradients;
        private int Width, Height;
        private const double step = Math.PI / 18;
        private const double bin = step * 2;
        public IAnalyser GetAnalyser(ref Bitmap image)
        {
            return new Analyser(ref image);
        }
        public Analyser() { }
        private Analyser(ref Bitmap image)
        {
            Width = image.Width;
            Height = image.Height;
            Color tmp;
            int i, j;
            PxlGradients = new double[3, Height, Width];
            for (i = 0; i < Height; i++)
                for (j = 0; j < Width; j++)
                {
                    tmp = image.GetPixel(j, i);
                    PxlGradients[0, i, j] = (new Rgb { R = tmp.R, G = tmp.G, B = tmp.B }).To<Lab>().L;
                }

            double Lx, Ly;
            for (i = 0; i < Height; i++)
                for (j = 0; j < Width; j++)
                {
                    if (j == 0 || j == Width - 1) Lx = PxlGradients[0, i, j];
                    else Lx = PxlGradients[0, i, j + 1] - PxlGradients[0, i, j - 1];
                    if (i == 0 || i == Height - 1) Ly = PxlGradients[0, i, j];
                    else Ly = PxlGradients[0, i + 1, j] - PxlGradients[0, i - 1, j];
                    PxlGradients[1, i, j] = Math.Sqrt(Lx * Lx + Ly * Ly);
                    PxlGradients[2, i, j] = Math.Atan(Ly / Lx) + Math.PI;
                }
        }
        public double[] GetDescriptors(Location window)
        {
            int x0 = window.x0;
            int y0 = window.y0;
            if (x0 + 80 > Width || y0 + 200 >= Height) throw new Exception("Окно выходит за границы изображения");
            int x1 = x0 + 80;
            int y1 = y0 + 200;

            int Cols = 80 / 8;
            int Rows = 200 / 8;
            double[,,] Cells = new double[Rows, Cols, 9];

            for (int i = y0; i < y1; i++)
                for (int j = x0; j < x1; j++)
                {
                    if (PxlGradients[2, i, j] > step && PxlGradients[2, i, j] <= step * 3)
                    {
                        Cells[(i - y0) / 8, (j - x0) / 8, 0] += PxlGradients[1, i, j] * (step * 3 - PxlGradients[2, i, j]) / bin;
                        Cells[(i - y0) / 8, (j - x0) / 8, 1] += PxlGradients[1, i, j] * (PxlGradients[2, i, j] - step) / bin;
                    }
                    else if (PxlGradients[2, i, j] > step * 3 && PxlGradients[2, i, j] <= step * 5)
                    {
                        Cells[(i - y0) / 8, (j - x0) / 8, 1] += PxlGradients[1, i, j] * (step * 5 - PxlGradients[2, i, j]) / bin;
                        Cells[(i - y0) / 8, (j - x0) / 8, 2] += PxlGradients[1, i, j] * (PxlGradients[2, i, j] - step * 3) / bin;
                    }
                    else if (PxlGradients[2, i, j] > step * 5 && PxlGradients[2, i, j] <= step * 7)
                    {
                        Cells[(i - y0) / 8, (j - x0) / 8, 2] += PxlGradients[1, i, j] * (step * 7 - PxlGradients[2, i, j]) / bin;
                        Cells[(i - y0) / 8, (j - x0) / 8, 3] += PxlGradients[1, i, j] * (PxlGradients[2, i, j] - step * 5) / bin;
                    }
                    else if (PxlGradients[2, i, j] > step * 7 && PxlGradients[2, i, j] <= step * 9)
                    {
                        Cells[(i - y0) / 8, (j - x0) / 8, 3] += PxlGradients[1, i, j] * (step * 9 - PxlGradients[2, i, j]) / bin;
                        Cells[(i - y0) / 8, (j - x0) / 8, 4] += PxlGradients[1, i, j] * (PxlGradients[2, i, j] - step * 7) / bin;
                    }
                    else if (PxlGradients[2, i, j] > step * 9 && PxlGradients[2, i, j] <= step * 11)
                    {
                        Cells[(i - y0) / 8, (j - x0) / 8, 4] += PxlGradients[1, i, j] * (step * 11 - PxlGradients[2, i, j]) / bin;
                        Cells[(i - y0) / 8, (j - x0) / 8, 5] += PxlGradients[1, i, j] * (PxlGradients[2, i, j] - step * 9) / bin;
                    }
                    else if (PxlGradients[2, i, j] > step * 11 && PxlGradients[2, i, j] <= step * 13)
                    {
                        Cells[(i - y0) / 8, (j - x0) / 8, 5] += PxlGradients[1, i, j] * (step * 13 - PxlGradients[2, i, j]) / bin;
                        Cells[(i - y0) / 8, (j - x0) / 8, 6] += PxlGradients[1, i, j] * (PxlGradients[2, i, j] - step * 11) / bin;
                    }
                    else if (PxlGradients[2, i, j] > step * 13 && PxlGradients[2, i, j] <= step * 15)
                    {
                        Cells[(i - y0) / 8, (j - x0) / 8, 6] += PxlGradients[1, i, j] * (step * 15 - PxlGradients[2, i, j]) / bin;
                        Cells[(i - y0) / 8, (j - x0) / 8, 7] += PxlGradients[1, i, j] * (PxlGradients[2, i, j] - step * 13) / bin;
                    }
                    else if (PxlGradients[2, i, j] > step * 15 && PxlGradients[2, i, j] <= step * 17)
                    {
                        Cells[(i - y0) / 8, (j - x0) / 8, 7] += PxlGradients[1, i, j] * (step * 17 - PxlGradients[2, i, j]) / bin;
                        Cells[(i - y0) / 8, (j - x0) / 8, 8] += PxlGradients[1, i, j] * (PxlGradients[2, i, j] - step * 15) / bin;
                    }
                    else if (PxlGradients[2, i, j] > step * 17)
                    {
                        Cells[(i - y0) / 8, (j - x0) / 8, 8] += PxlGradients[1, i, j];
                    }
                    else if (PxlGradients[2, i, j] <= 0)
                    {
                        Cells[(i - y0) / 8, (j - x0) / 8, 0] += PxlGradients[1, i, j];
                    }
                }
            double[,] Blocks = new double[Rows - 1, Cols - 1];
            for (int i = 0; i < Rows - 1; i++)
                for (int j = 0; j < Cols - 1; j++)
                {
                    for (int k = 0; k < 9; k++)
                        Blocks[i, j] += Cells[i, j, k] * Cells[i, j, k] + Cells[i + 1, j, k] * Cells[i + 1, j, k] + Cells[i, j + 1, k] * Cells[i, j + 1, k] + Cells[i + 1, j + 1, k] * Cells[i + 1, j + 1, k];
                    Blocks[i, j] = Math.Sqrt(Blocks[i, j] + 1);
                }
            double[] Descriptors = new double[(Rows - 1) * (Cols - 1) * 4 * 9];
            for (int i = 0; i < Rows - 1; i++)
                for (int j = 0; j < Cols - 1; j++)
                    for (int k = 0; k < 9; k++)
                    {
                        Descriptors[i * Rows + j * Cols + k] = Cells[i, j, k] / Blocks[i, j];
                        Descriptors[i * Rows + j * Cols + k + 4] = Cells[i, j + 1, k] / Blocks[i, j];
                        Descriptors[i * Rows + j * Cols + k + 8] = Cells[i + 1, j, k] / Blocks[i, j];
                        Descriptors[i * Rows + j * Cols + k + 16] = Cells[i + 1, j + 1, k] / Blocks[i, j];
                    }
            return Descriptors;
        }
    }
}
