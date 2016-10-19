namespace App.Common
{
    public class Dimension
    {
        public long Width { get; set; }
        public long Height { get; set; }
        public Dimension(long width, long height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
