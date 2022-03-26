using EpamTaskTwo.Matherials;
using EpamTaskTwo.Chipboards;

namespace EpamTaskTwo.Operations
{
    /// <summary>
    /// Class for common edge processings
    /// </summary>
    public abstract class EdgeProcessings : IOperation
    {
        public virtual double Cost { get; private set; }
        public double TotalCost { get { return NecessaryMatherial.TotalCost + Cost; } }
        public IMatherial NecessaryMatherial { get; }
        public IFullChipboard Countertop { get; }
        public EdgeProcessings(EdgeOperationsMatherial matherial, IFullChipboard countertop, double cost)
        {
            if (matherial.Length < 2 * (countertop.Width + countertop.Length) || matherial.Width < countertop.Height)
                throw new ArgumentException("This matheial doesn't fit the edge of countertop");
            NecessaryMatherial = matherial;
            Countertop = countertop;
            Cost = cost;
        }
    }
}
