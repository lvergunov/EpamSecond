using System.Xml;
using EpamTaskTwo.XMLWork;
using EpamTaskTwo.MachineWork;
using EpamTaskTwo.Matherials;
using EpamTaskTwo.Chipboards;

namespace EpamTaskTwo.Factory
{
    /// <summary>
    /// A class that reads the value of an xml file and creates an object
    /// </summary>
    public class FullChipboardReader : AbstractReaderXml, IAbstractChipboardReader
    {
        public FullChipboardReader(string fileName) : base(fileName) { }
        public FullChipboardReader(XmlReader reader) : base(reader)
        {
        }
        public IChipboard GetChipboard()
        {
            return Read(typeof(FullChipboard)) as IChipboard;
        }
    }
}
