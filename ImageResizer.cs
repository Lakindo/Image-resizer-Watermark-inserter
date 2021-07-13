using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace ImgResizer
{
    class ImageResizer
    {
        static void Main(string[] args)
        {

            Image image = Image.FromStream(File.OpenRead("C:\\Users\\Lakindo\\Desktop\\Things\\Pictures\\kris bald.png"));
            var destRect = new Rectangle(0, 0, 700, 576);
            var output = new Bitmap(500, 376);

            output.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var gr = Graphics.FromImage(output))
            {

                gr.CompositingMode = CompositingMode.SourceCopy;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;


                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);

                    gr.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            image.Dispose();
            output.Save("C:\\Users\\Lakindo\\Desktop\\Things\\Pictures\\kris bald resized.png");

        }
    }
}