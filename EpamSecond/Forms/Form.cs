using EpamTaskTwo.Measure;
using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Forms
{
        public abstract class Form : IMainMeasures, IExtendedMeasures
        {
            public double Width { get; protected set; }
            public double Height { get; protected set; }
            public double Length { get; protected set; }
            public virtual double SizeOfTop { get; }
            public virtual double SizeOfFront { get; }
            public virtual double SizeOfSide { get; }
            public double Volume { get { return SizeOfTop * Height; } }
            public abstract bool IsPointInside(Point point);
            public Form(double length, double width, double height)
            {
                Width = width; Length = length; Height = height;
            }
            public bool ArePointsInside(List<Point> points)
            {
                var searchedPoints = from point in points where IsPointInside(point) select point;
                return searchedPoints != null;
            }
        }
    }
