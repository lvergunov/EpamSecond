using EpamTaskTwo.Matherials;
using EpamTaskTwo.Forms;

namespace EpamTaskTwo.Legs
{
    public class OvalLeg : OvalForm,ILeg
    {
        public double TotalCost { get; private set; }
        public uint SpecialNumber { get; }
        public IMatherial Matherial { get; }
        public OvalLeg(NotChipboardForLegs matherial, double totalCost) : base(matherial.Length, matherial.Width, matherial.Height)
        {
            Matherial = matherial;
            TotalCost = totalCost;
        }
        public Type Form { get { return base.GetType(); } }
        public void ChangeCost(double newCost) { TotalCost = newCost; }
        public override string ToString()
        {
            return $"Oval leg. Width: {Width}, Length: { Length}, Height: {Height}. Total cost: {TotalCost}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is OvalLeg leg) return Width == leg.Width && Length == leg.Length && Height == leg.Height && Matherial == leg.Matherial;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
