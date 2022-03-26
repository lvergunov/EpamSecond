namespace EpamTaskTwo.MachineWork
{
    public class Machine : IMachine
    {
        public string Information { get; set; }
        public double TotalCost { get { return CostOfMM; } }
        public double CostOfMM { get; private set; }
        public double MaxPossibleWidth { get; }
        public double MaxPossibleLength { get; }
        public double MaxPossibleHeight { get; }
        public bool AllowNonRectangular { get; }
        public Machine(double length,double width,double height,bool nonRectangular,double costMM)
        {
            MaxPossibleLength = length;
            MaxPossibleWidth = width;
            MaxPossibleHeight = height;
            AllowNonRectangular = nonRectangular;
            ChangeCost(costMM);
        }
        public int CompareTo(object? obj)
        {
            if (obj is IMachine mach) return CostOfMM.CompareTo(mach.CostOfMM);
            else throw new ArgumentException("Incorrect param");
        }
        public void ChangeCost(double newCost) { CostOfMM = newCost; }
        public override string ToString()
        {
            return $"Machine. Max params are: width {MaxPossibleWidth}, length {MaxPossibleLength}, height {MaxPossibleHeight}" +
                $"Cost of 1 mm cut {CostOfMM}. Other information: {Information}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is IMachine mach) return MaxPossibleWidth == mach.MaxPossibleWidth && MaxPossibleLength == mach.MaxPossibleLength &&
                     MaxPossibleHeight == mach.MaxPossibleHeight && CostOfMM == mach.CostOfMM;
            else return false;
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
