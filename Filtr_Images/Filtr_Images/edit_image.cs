using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtr_Images
{
    public static class edit_image
    {
        public static Image filtr(this Image in_Image, int red, int green, int blue)
        {
            Bitmap out_Image = new Bitmap(in_Image.Width, in_Image.Height);
            Graphics img_graphic = Graphics.FromImage(out_Image);

            img_graphic.DrawImage(in_Image, 0, 0);
            img_graphic.FillRectangle(new SolidBrush(Color.FromArgb(90, red, green, blue)), 0, 0, out_Image.Width, out_Image.Height);
            return out_Image;
        }
    }
}
