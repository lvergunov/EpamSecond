using EpamTaskTwo.Matherials;
using EpamTaskTwo.Forms;

namespace EpamTaskTwo.Legs
{
    public class CircleLeg : CircularForm,ILeg
    {
        public double TotalCost { get; private set; }
        public IMatherial Matherial { get; }
        public CircleLeg(NotChipboardForLegs matherial,double cost) : base(matherial.Width,matherial.Height)
        {
            if (matherial.Width != matherial.Length) throw new ArgumentException("Current form is not circular");
            Matherial = matherial;
            TotalCost = cost;
        }
        public Type Form { get { return base.GetType(); } }
        public void ChangeCost(double newCost) { TotalCost = newCost; }
        public override string ToString()
        {
            return $"Circular leg. Width: {Width}, Length: { Length}, Height: {Height}. Total cost: {TotalCost}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is CircleLeg leg) return Width == leg.Width && Length == leg.Length && Height == leg.Height && Matherial == leg.Matherial;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
