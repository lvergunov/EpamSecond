using EpamTaskTwo.XMLWork;

namespace EpamTaskTwo.Measure
{
    public interface IComponent : IXMLReflector
    {
        public double TotalCost { get; }
    }
}
