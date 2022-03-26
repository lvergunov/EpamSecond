using System.Xml;
using EpamTaskTwo.XMLWork;
using EpamTaskTwo.Operations;
using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Factory
{
    /// <summary>
    /// A class that reads the value of an xml file and creates an object
    /// </summary>
    public class CutReader : AbstractReaderXml, IOperationReader
    {
        public CutReader(string fileName) : base(fileName) { }
        public CutReader(XmlReader reader) : base(reader)
        {
        }
        public IOperation GetOperation()
        {
            return Read(typeof(RectangularCut)) as IOperation;
        }
    }
}