using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Forms
{
    /// <summary>
    /// Class for rectangular objects
    /// </summary>
    public abstract class Rectangular : Form
    {
        public List<Point> MainPoints { get; set; }
        public override double SizeOfTop { get { return this.Width * this.Length; } }
        public override double SizeOfSide{ get { return this.Width * this.Height; } }
        public override double SizeOfFront { get { return this.Length * this.Height; } }
        public Rectangular(double length, double width, double height) : base(length, width, height){
            MainPoints = new List<Point>(8);
            MainPoints.AddRange(new Point[8] {
                new Point(0, 0, 0), new Point(Length, 0, 0), new Point(0, Width, 0), new Point(Length, Width, 0),
                new Point(0, 0, Height), new Point(Length, 0, Height), new Point(0, Width, Height), new Point(Length, Width, Height) });
        }
        public override bool IsPointInside(Point point)
        {
            if (point >= MainPoints[0] && point <= MainPoints[7] || point <= MainPoints[0] && point >= MainPoints[7]) return true;
            else return false;
        }
    }
}
