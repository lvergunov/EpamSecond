using System.Xml;
using EpamTaskTwo.XMLWork;
using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Factory
{
    public class PointFromXML : AbstractReaderXml
    {
        public PointFromXML(XmlReader reader) : base(reader) { }
        public Point GetPoint()
        {
            List<string> nodeNames = new string[] { "X","Y","Z"}.ToList();
            Dictionary<string, object> nodes = ReadFile(nodeNames);
            if (nodes.Count != nodeNames.Count) throw new NotImplementedException("Impossible to read");
            else return new Point(Convert.ToDouble(nodes["X"]),Convert.ToDouble(nodes["Y"]),
                Convert.ToDouble(nodes["Z"]));
        }
    }
}
