using EpamTaskTwo.XMLWork;

namespace EpamTaskTwo.MachineWork
{
    public class Point : IXMLReflector
    {
        public static bool operator >=(Point pointOne, Point pointTwo){
            if (pointOne.X >= pointTwo.X && pointOne.Y >= pointTwo.Y && pointOne.Z >= pointTwo.Z) return true;
            else return false;
        }
        public static bool operator <=(Point pointOne, Point pointTwo)
        {
            if (pointOne.X <= pointTwo.X && pointOne.Y <= pointTwo.Y && pointOne.Z <= pointTwo.Z) return true;
            else return false;
        }
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public Point(double x, double y,double z)
        {
            if (x < 0 || y < 0 || z < 0)
                throw new ArgumentException("The point coordinate value cannot be less than zero. " +
                    "The origin of coordinates is in the lower left nearest corner of the full chipboard");
            X = x; Y = y; Z = z; 
        }
        public override string ToString()
        {
            return $"Point ({X},{Y},{Z})";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Point pt) return this.X == pt.X && this.Y == pt.Y && this.Z == pt.Z;
            return false;
        }
        public override int GetHashCode()
        {
            return Tuple.Create(X,Y,Z).GetHashCode();
        }
    }
}
