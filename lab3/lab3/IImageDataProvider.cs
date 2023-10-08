using lab3.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public interface IImageDataProvider
    {
        Bitmap GetNextImage(out Location location);
        int CurrentImageIndex { get; }
    }
}
