using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Forms
{
    /// <summary>
    /// Class for oval objects
    /// </summary>
    public abstract class OvalForm : Form
    {
        public override double SizeOfTop { get { return Math.PI * this.Width * this.Length*0.25; } }
        public override double SizeOfSide 
        {
            get { 
                return 2 * Math.PI * Math.Sqrt((Math.Pow(this.Width/2,2)+Math.Pow(this.Length/2,2))/8); 
            } 
        }
        public OvalForm(double bigDiagon, double smallDiagon, double height):base(bigDiagon, smallDiagon, height)
        {
        }
        public override double SizeOfFront { get {return this.SizeOfSide; } }
        public override bool IsPointInside(Point point)
        {
            return point.X / 0.5 * Length + point.Y / 0.5 * Width <= 1 && point.Z <= Height;
        }
    }
}
