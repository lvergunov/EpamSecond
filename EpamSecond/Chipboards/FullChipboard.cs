using EpamTaskTwo.Measure;
using EpamTaskTwo.MachineWork;
using EpamTaskTwo.Forms;
using EpamTaskTwo.Matherials;

    /// <summary>
    /// Regular Rectangular Material Class
    /// </summary>

namespace EpamTaskTwo.Chipboards
{
    public class FullChipboard : Rectangular, IFullChipboard
    {
        public double TotalCost { get { return Volume * ChipboardCost.CostOfMMCub; } }
        public FullChipboard(double length,double width,double height) : base(length,width,height) {
        }
        /// <summary>
        /// A method for determining whether it is possible to cut chipboard leaving a rectangular material
        /// </summary>
        /// <param name="cut">Cut params</param>
        /// <returns>Possibly or not</returns>
        public bool TryResize(ICut cut)
        {
            if (this.Width-cut.Width==0 && this.Height-cut.Height==0 || this.Length-cut.Length==0 &&
                this.Width - cut.Width == 0 || this.Height - cut.Height == 0 &&
                this.Length - cut.Length == 0) return true;
            else return false;
        }
        /// <summary>
        /// A method that produces sawing or uses whole chipboard
        /// </summary>
        /// <param name="cut"></param>
        /// <returns></returns>
        public ResultOfCut ChangeMeasures(ICut cut) {
            if (TryResize(cut))
            {
                double tempWidth = this.Width - cut.Width;
                double tempLength = this.Length - cut.Length;
                double tempHeight = this.Height - cut.Height;
                if (tempWidth == 0 && tempHeight == 0 && tempLength == 0) return ResultOfCut.Destroyed;
                if (tempWidth != 0) this.Width = tempWidth;
                if (tempLength != 0) this.Length = tempLength;
                if (tempHeight != 0) this.Height = tempHeight;
                return ResultOfCut.CutAsFull;
            }
            return ResultOfCut.Impossible;
        }
        public int CompareTo(object? obj)
        {
            if (obj is not IChipboard cb) throw new ArgumentException();
            else return Volume.CompareTo(cb.Volume);
        }
        public override string ToString()
        {
            return $"Full chipboard. Width: {Width}, Length: {Length}, Height: {Height}, Total cost: {TotalCost}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is IFullChipboard fullCB) return fullCB.Width == Width && fullCB.Height == Height && fullCB.Length == Length;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
