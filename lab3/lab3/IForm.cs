using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public interface IForm
    {
        void ShowView();

        void CloseView();

        void DisplayImage(Bitmap image);

        void DisplayMessage(string message);
    }
}
