namespace EpamTaskTwo.ReadyProduct
{
    public class Furniture : IFurniture
    {
        public double TotalCost { get; private set; }
        public Furniture(double totalCost)
        {
            TotalCost = totalCost;
        }
        public void ChangeCost(double newCost) {
            TotalCost = newCost;
        }
    }
}
