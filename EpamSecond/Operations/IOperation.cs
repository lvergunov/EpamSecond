using EpamTaskTwo.Matherials;
using EpamTaskTwo.XMLWork;

namespace EpamTaskTwo.Operations
{
    public interface IOperation : IXMLReflector 
    {
        public double Cost { get; }
        public IMatherial NecessaryMatherial { get; }
    }
}
