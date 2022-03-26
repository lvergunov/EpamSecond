using EpamTaskTwo.Matherials;
using EpamTaskTwo.Chipboards;

namespace EpamTaskTwo.Operations
{
    public class PlasticInsert : EdgeProcessings
    {
        public override double Cost
        {
            get
            {
                if (NecessaryMatherial is Plastic plastic) return 2 * (Countertop.Width + Countertop.Length) * plastic.CostOfMM +
                        Countertop.Height * plastic.CostOfMM;
                else return 0;
            }
        }
        public PlasticInsert(Plastic plastic,IFullChipboard countertop,double cost) :base(plastic,countertop,cost) { }
        public override string ToString()
        {
            return $"Insert plastic to an edge of countertop. Plastic info: {NecessaryMatherial.ToString}," +
                $"Countertop info: {Countertop}, total cost is {TotalCost}";
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
