using EpamTaskTwo.Chipboards;
using EpamTaskTwo.Legs;
using EpamTaskTwo.MachineWork;
using EpamTaskTwo.ReadyProduct;
using EpamTaskTwo.Matherials;
using EpamTaskTwo.Operations;

namespace EpamTaskTwo.Factory
{
    /// <summary>
    /// Interface to implement the factory method
    /// </summary>
    public interface IAbstractChipboardReader
    {
        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns></returns>
        public IChipboard GetChipboard();
    }
}
