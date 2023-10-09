using System;
using System.Collections.Generic;

namespace lab2
{
    public static class GeometricViewModel
    {
        public static int CalculateArea(int[,] labels, int label)
        {
            int area = 0;
            for (int y = 0; y < labels.GetLength(1); y++)
            {
                for (int x = 0; x < labels.GetLength(0); x++)
                {
                    if (labels[x, y] == label)
                    {
                        area++;
                    }
                }
            }
            return area;
        }

        public static Tuple<int, int> CalculateCentroid(int[,] labels, int label)
        {
            int area = CalculateArea(labels, label);
            int cx = 0;
            int cy = 0;
            for (int y = 0; y < labels.GetLength(1); y++)
            {
                for (int x = 0; x < labels.GetLength(0); x++)
                {
                    if (labels[x, y] == label)
                    {
                        cx += x;
                        cy += y;
                    }
                }
            }
            cx /= area;
            cy /= area;
            return Tuple.Create(cx, cy);
        }

        public static int CalculatePerimeter(int[,] labels, int label)
        {
            int perimeter = 0;
            for (int y = 0; y < labels.GetLength(1); y++)
            {
                for (int x = 0; x < labels.GetLength(0); x++)
                {
                    if (labels[x, y] == label)
                    {
                        if (x == 0 || x == labels.GetLength(0) - 1 || y == 0 || y == labels.GetLength(1) - 1)
                        {
                            perimeter++;
                        }
                        else if (labels[x, y - 1] != label || labels[x, y + 1] != label || labels[x - 1, y] != label || labels[x + 1, y] != label)
                        {
                            perimeter++;
                        }
                    }
                }
            }
            return perimeter;
        }

        public static double CalculateCompactness(int[,] labels, int label)
        {
            int area = CalculateArea(labels, label);
            int perimeter = CalculatePerimeter(labels, label);
            double compactness = 4 * Math.PI * area / (perimeter * perimeter);
            return compactness;
        }

        public static double CalculateOrientation(int[,] labels, int label)
        {
            var centroid = CalculateCentroid(labels, label);
            double cx = centroid.Item1;
            double cy = centroid.Item2;
            double ixx = 0;
            double iyy = 0;
            double ixy = 0;
            for (int y = 0; y < labels.GetLength(1); y++)
            {
                for (int x = 0; x < labels.GetLength(0); x++)
                {
                    if (labels[x, y] == label)
                    {
                        double dx = x - cx;
                        double dy = y - cy;
                        ixx += dx * dx;
                        iyy += dy * dy;
                        ixy += dx * dy;
                    }
                }
            }
            return 0.5 * Math.Atan2(2 * ixy, ixx - iyy);
        }

        public static double CalculateEccentricity(int[,] labels, int label)
        {
            int area = CalculateArea(labels, label);
            var centroid = CalculateCentroid(labels, label);
            double cx = centroid.Item1;
            double cy = centroid.Item2;
            double ixx = 0;
            double iyy = 0;
            double ixy = 0;
            for (int y = 0; y < labels.GetLength(1); y++)
            {
                for (int x = 0; x < labels.GetLength(0); x++)
                {
                    if (labels[x, y] == label)
                    {
                        double dx = x - cx;
                        double dy = y - cy;
                        ixx += dx * dx;
                        iyy += dy * dy;
                        ixy += dx * dy;
                    }
                }
            }
            double lambda1 = (ixx + iyy + Math.Sqrt((ixx - iyy) * (ixx - iyy) + 4 * ixy * ixy)) / (2 * area);
            double lambda2 = (ixx + iyy - Math.Sqrt((ixx - iyy) * (ixx - iyy) + 4 * ixy * ixy)) / (2 * area);
            double eccentricity = Math.Sqrt(1 - Math.Min(lambda1, lambda2) / Math.Max(lambda1, lambda2));
            return eccentricity;
        }
    }
}
