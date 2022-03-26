using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Matherials
{
    /// <summary>
    /// Class separating wooden legs from the rest
    /// </summary>
    public abstract class NotChipboardForLegs : IMatherial
    {
        public double TotalCost { get; protected set; }
        public double Width { get; protected set; }
        public double Length { get; protected set; }
        public double Height { get; protected set; }
    }
}
