namespace EpamTaskTwo.Matherials
{
    /// <summary>
    /// abstract class to represent all kinds of matherials for edge processing
    /// </summary>
    public abstract class EdgeOperationsMatherial : IMatherial
    {
        public double CostOfMM { get; }
        public uint SpecialNumber { get; }
        public double Width { get; }
        public double Length { get; }
        public double Height { get; }
        public double Size { get { return Width * Length; } }
        public double TotalCost { get { return CostOfMM * (Width + Length); } }
        public EdgeOperationsMatherial(double length, double width, double height, double cost)
        {
            Width = width;
            Length = length;
            Height = height;
            CostOfMM = cost;
        }
    }
}
