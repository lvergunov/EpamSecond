using EpamTaskTwo.MachineWork;
using EpamTaskTwo.Measure;

namespace EpamTaskTwo.Matherials
{
    /// <summary>
    /// Indicates the possibility of sawing an object
    /// </summary>
    public interface IResizable
    {
        public ResultOfCut ChangeMeasures(ICut cut);
        public bool TryResize(ICut cut);
    }
}
