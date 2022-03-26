namespace EpamTaskTwo.Matherials
{
    public class Paper : EdgeOperationsMatherial
    {
        public Paper(double length,double width,double height,double cost):base(length,width,height,cost){ }
        public override string ToString()
        {
            return $"Paper for edge processings. Width {Width}, Length {Length}, Thickness {Height}. Cost of " +
                $"one MM is {CostOfMM}";
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
