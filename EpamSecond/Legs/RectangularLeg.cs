using EpamTaskTwo.Matherials;
using EpamTaskTwo.Forms;
using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Legs
{
    public class RectangularLeg : Rectangular,ILeg
    {
        public double TotalCost { get { return Matherial.TotalCost; } }
        public uint SpecialNumber { get; }
        public IMatherial Matherial { get; }
        public RectangularLeg(IMatherial matherial) : base(matherial.Length, matherial.Width, matherial.Height)
        {
            Matherial = matherial;
        }
        public Type Form { get { return base.GetType(); } }
        public override string ToString()
        {
            return $"Rectangular leg. Width: {Width}, Length: { Length}, Height: {Height}. Total cost: {TotalCost}. " +
                $"Matherial is { Matherial.ToString }";
        }
        public override bool Equals(object? obj)
        {
            if (obj is RectangularLeg leg) return Width == leg.Width && Length == leg.Length && Height == leg.Height && Matherial == leg.Matherial;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
