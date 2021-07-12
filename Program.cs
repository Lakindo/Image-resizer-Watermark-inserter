using System;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace imgWatermark
{

    public class Watermarker : IDisposable
    {
        public Watermarker(string v)
        {
        }

        void IDisposable.Dispose() { }

        static void Main(string[] args)
        {
            using (Watermarker watermarker = new Watermarker("C:\\Users\\Lakindo\\Desktop" +
                "\\Things\\Pictures\\kris_bald_resized.png"))
            {
                using (ImageWatermark watermark = new ImageWatermark ("C:\\Users\\Lakindo\\Desktop\\Things\\" +
                    "Pictures\\pepelaughpoint.png"))
                {
                    watermark.X = 30;
                    watermark.Y = 50;

                    watermark.Add(watermark);
                    watermark.Save("C:\\Users\\Lakindo\\Desktop\\Things\\Pictures\\kris_bald_resized.png");
                }
            }
        }
    }
}