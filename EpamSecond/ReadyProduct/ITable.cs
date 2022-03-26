using EpamTaskTwo.Chipboards;
using EpamTaskTwo.Legs;
using EpamTaskTwo.Operations;
using EpamTaskTwo.XMLWork;

using EpamTaskTwo.Measure;

namespace EpamTaskTwo.ReadyProduct
{
    public interface ITable : IXMLReflector 
    {
        public string Name { get; }
        public IFullChipboard Countertop { get; }
        public List<ILeg> Legs { get; }
        public List<IOperation> Operations { get; }
        public List<IFurniture> Furnitures { get; }
        public double TotalCost { get; }
    }
}
