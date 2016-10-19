using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace App.Common.Helpers
{
    public class ImageHelper
    {
        public static string ToBase64(string fileName, byte[] content, ThumbnailSize size = ThumbnailSize.Small)
        {
            string fileExt = Path.GetExtension(fileName).Replace(".", "").ToUpper();
            switch (fileExt)
            {
                case FileContentExt.Png:
                case FileContentExt.Jpg:
                case FileContentExt.Jpeg:
                    return ToBase64(content, size);
                case FileContentExt.Doc:
                case FileContentExt.Pdf:
                case FileContentExt.Xsl:
                case FileContentExt.Xslx:
                    return ToBase64OfIcon(fileExt, size);
                default:
                    return ToBase64OfIcon(FileContentExt.UnSupported, size);
            }
        }

        private static string ToBase64(byte[] content, ThumbnailSize size)
        {
            Dimension photoSize = GetPhotoSize(size);
            Bitmap image = Resize(content, photoSize.Width, photoSize.Height);
            return ToBase64(image);

        }

        public static byte[] GetContent(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public static Bitmap GetThumbnail(string fileName, byte[] content, ThumbnailSize size)
        {
            string fileExt = Path.GetExtension(fileName).Replace(".", "").ToUpper();
            switch (fileExt)
            {
                case FileContentExt.Png:
                case FileContentExt.Jpg:
                case FileContentExt.Jpeg:
                    return GetThumbnail(content, size);
                case FileContentExt.Doc:
                case FileContentExt.Pdf:
                case FileContentExt.Xsl:
                case FileContentExt.Xslx:
                    return GetThumbnailOfIcon(fileExt, size);
                default:
                    return GetThumbnailOfIcon(FileContentExt.UnSupported, size);
            }
        }

        private static Bitmap GetThumbnail(byte[] content, ThumbnailSize size)
        {
            Dimension photoSize = GetPhotoSize(size);
            return Resize(content, photoSize.Width, photoSize.Height);
        }

        private static Bitmap GetThumbnailOfIcon(string fileExt, ThumbnailSize size)
        {
            throw new NotImplementedException();
        }

        private static string ToBase64(Bitmap image)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Png);
            return string.Format("data:{0};base64,{1}", "image/png", Convert.ToBase64String(stream.GetBuffer()));
        }

        private static Bitmap Resize(byte[] content, long maxWidth, long maxHeight)
        {
            MemoryStream memoryStream = new MemoryStream(content);
            Image image = Image.FromStream(memoryStream);

            maxWidth = maxWidth > 0 ? maxWidth : image.Width;
            maxHeight = maxHeight > 0 ? maxHeight : image.Height;

            float widthRatio = (float)image.Width / maxWidth;
            float heightRatio = (float)image.Height / maxHeight;

            double resizeWidth = image.Width;
            double resizeHeight = image.Height;

            double aspect = resizeWidth / resizeHeight;

            if (resizeWidth > maxWidth)
            {
                resizeWidth = maxWidth;
                resizeHeight = resizeWidth / aspect;
            }
            if (resizeHeight > maxHeight)
            {
                aspect = resizeWidth / resizeHeight;
                resizeHeight = maxHeight;
                resizeWidth = resizeHeight * aspect;
            }

            Rectangle destRect = new Rectangle(0, 0, (int)resizeWidth, (int)resizeHeight);
            Bitmap destImage = new Bitmap((int)resizeWidth, (int)resizeHeight);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private static Dimension GetPhotoSize(ThumbnailSize size)
        {
            switch (size)
            {
                case ThumbnailSize.Small:
                    return new Dimension(64, 64);
                case ThumbnailSize.Medium:
                    return new Dimension(128, 128);
                case ThumbnailSize.Large:
                    return new Dimension(256, 256);
                case ThumbnailSize.Ogirin:
                default:
                    return new Dimension(0, 0);
            }
        }

        private static string ToBase64OfIcon(string fileExt, ThumbnailSize size)
        {
            return string.Empty;
        }
    }
}
