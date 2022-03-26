using EpamTaskTwo.Measure;

namespace EpamTaskTwo.Matherials
{
    public class Plastic : EdgeOperationsMatherial
    {
        public Plastic(double length, double width, double height,double cost) :base(length,width,height,cost)
        {
        }
        public override string ToString()
        {
            return $"Plastic component. Width is {Width}, Length is {Length}, Height: {Height}," +
                $"Cost is { TotalCost }";
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
