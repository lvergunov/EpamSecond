using EpamTaskTwo.Matherials;
using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Chipboards
{
    /// <summary>
    /// Interface for full chipboard
    /// </summary>
    public interface IFullChipboard : IChipboard
    {
        public List<Point> MainPoints { get; }
    }
}
