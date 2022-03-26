using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Forms
{
    /// <summary>
    /// Class for circular objects
    /// </summary>
    public abstract class CircularForm : Form
    {
        public override double SizeOfTop { 
            get { return Math.Pow(this.Width/2, 2) * Math.PI; }
        }
        public override double SizeOfSide
        {
            get { return 2 * Math.PI * this.Width / 2 * this.Height; }
        }
        /// <summary>
        /// sidewall area
        /// </summary>

        public override double SizeOfFront
        {
            get { return this.SizeOfSide; }
        }
        public double Radious { get { return Width / 2; } }
        public CircularForm(double diametr, double height) : base(diametr,diametr,height) { }
        /// <summary>
        /// Method to determine if a point is inside a shape relative to the bottom nearest left corner
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>

        public override bool IsPointInside(Point point)
        {
            return Math.Pow(point.X - Length / 2, 2) + Math.Pow(point.Y - Width / 2, 2) <= Radious && point.Z < Height;
        }
    }
}

