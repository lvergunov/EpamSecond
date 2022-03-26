using EpamTaskTwo.Measure;

namespace EpamTaskTwo.Matherials
{
    /// <summary>
    /// Class steel for legs
    /// </summary>
    public class Steel : NotChipboardForLegs
    {
        public Steel(double width,double length,double height)
        {
            Width = width; Length = length; Height = height; 
        }
        public override string ToString()
        {
            return $"Steel matherial. Width {Width}, Length {Length}, Height {Height}.";
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
