using EpamTaskTwo.Measure;
using EpamTaskTwo.Matherials;
using EpamTaskTwo.Legs;
using EpamTaskTwo.Chipboards;

namespace EpamTaskTwo.MachineWork
{
    public interface IMachine : IComponent, IComparable
    {
        public double CostOfMM { get; }
        public string Information { get; set; } 
        public double MaxPossibleWidth { get; }
        public double MaxPossibleLength { get; }
        public double MaxPossibleHeight { get; }
        public bool AllowNonRectangular { get; }
    }
}
