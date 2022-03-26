using EpamTaskTwo.Matherials;
using EpamTaskTwo.MachineWork;
using EpamTaskTwo.Chipboards;

namespace EpamTaskTwo.Creators
{
    public abstract class ChipboardCreator
    {
        public virtual IChipboard FactoryMethod(double width, double length, double height) {
            throw new ArgumentException("Impossible");
        }
        public virtual IChipboard FactoryMethod(IChipboard chipboard, ICut cutParams)
        {
            throw new ArgumentException("Impossible");
        }
        public virtual IChipboard ReadXML(string fileName)
        {
            throw new ArgumentException("Impossible");
        }
    }
}