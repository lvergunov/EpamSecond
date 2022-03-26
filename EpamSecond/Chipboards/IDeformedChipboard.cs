using EpamTaskTwo.MachineWork;
using EpamTaskTwo.Matherials;

namespace EpamTaskTwo.Chipboards
{
    /// <summary>
    /// Interface for used chipboards
    /// </summary>
    public interface IDeformedChipboard : IChipboard
    {
        public List<ICut> Cuts { get; }
        public bool IsPointInside(Point point);
        public bool ArePointsInside(List<Point> points);
        public List<Point> ControlPoints { get; }
    }
}
