using EpamTaskTwo.Matherials;
using EpamTaskTwo.Chipboards;

namespace EpamTaskTwo.Operations
{
    public class PaperPasting : EdgeProcessings
    {
        public override double Cost { get {
                if (NecessaryMatherial is Paper paper) return  2 * (Countertop.Width + Countertop.Length) * paper.CostOfMM +
                        Countertop.Height*paper.CostOfMM;
            else return 0;
            } 
        }
        public PaperPasting(Paper paper,IFullChipboard countertop,double cost) : base(paper,countertop,cost) { }
        public override string ToString()
        {
            return $"Pasting countertop by paper. Countertop info: {Countertop.ToString}." +
                $". Paper info: {NecessaryMatherial.ToString}. Total cost: {TotalCost}";
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
