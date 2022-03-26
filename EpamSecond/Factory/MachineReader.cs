using System.Xml;
using EpamTaskTwo.XMLWork;
using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Factory
{
    /// <summary>
    /// A class that reads the value of an xml file and creates an object
    /// </summary>
    public class MachineReader : AbstractReaderXml, IMachineCreator
    {
        public MachineReader(string fileName, System.Text.Encoding encoding) : base(fileName, encoding) { }
        public MachineReader(string fileName) : base(fileName) { }
        public MachineReader(XmlReader reader) : base(reader)
        {
        }
        public IMachine GetMachine()
        {
            return Read(typeof(Machine)) as IMachine;
        }
    }
}
