using EpamTaskTwo.Measure;
using System.Xml;
using System.Reflection;
using EpamTaskTwo.Storage;
using EpamTaskTwo.Chipboards;
using EpamTaskTwo.Matherials;

namespace EpamTaskTwo.XMLWork
{
    public class AbstractReaderXml : AbstractReader
    {
        public AbstractReaderXml(XmlReader reader) {
            Reader = reader;
        }
        public AbstractReaderXml(string fileName)
        {
            ReadNewXML(fileName);
        }
        public AbstractReaderXml(string fileName, System.Text.Encoding encoding)
        {
            ReadNewXML(fileName,encoding);
        }

        protected override void ReadNewXML(string fileName)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            string filePath = Directory.GetCurrentDirectory() + @"\XMLStorage\" + fileName + ".xml";
            settings.IgnoreWhitespace = true;
            Reader = XmlReader.Create(filePath,settings);
        }
        protected override void ReadNewXML(string fileName, System.Text.Encoding encoding)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            string filePath = Directory.GetCurrentDirectory() + @"\XMLStorage\" + fileName + ".xml";
            settings.IgnoreWhitespace = true;
            _stream = new StreamReader(filePath, encoding);
            Reader = XmlReader.Create(_stream, settings);
        }
        public IXMLReflector Read(Type type)
        {
            IXMLReflector result = ReadObject(type);
            if(_stream!=null) _stream.Close();
            Reader.Close();
            return result;
        }
        protected IXMLReflector ReadObject(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            ConstructorParams constructor = new ConstructorParams();
            List<string> mainNodes = constructor.GetNodeNames(type.FullName);
            if (mainNodes.Count == 0) throw new NotImplementedException("Impossible to parse");
            var constrLinq = from con in constructors
                             where con.GetParameters().Length == mainNodes.Count
                             select con;
            ConstructorInfo constructorInfo = constrLinq.FirstOrDefault();
            Dictionary<string,object> innerConstr = new Dictionary<string, object>(mainNodes.Count);
            while (Reader.Read()) {
                if (Reader.NodeType == XmlNodeType.EndElement && Reader.Name == type.FullName) break;
                if(Reader.NodeType == XmlNodeType.Element && Reader.Name == "Object")
                {
                    Reader.MoveToFirstAttribute();
                    if (mainNodes.Contains(Reader.Value))
                    {
                        Reader.MoveToElement();
                        Type innerType = Type.GetType(Reader.Name);
                        innerConstr.Add(Reader.Name,ReadObject(innerType));
                    }
                }
                if(Reader.NodeType == XmlNodeType.Element && Reader.Name == "Field")
                {
                    Reader.MoveToAttribute("Name");
                    if (mainNodes.Contains(Reader.Value))
                    {
                        string name = Reader.Value;
                        Reader.MoveToAttribute("Type");
                        string ttype = Reader.Value;
                        Reader.MoveToAttribute("Value");
                        innerConstr.Add(name,constructor.Parse(ttype,Reader.Value));
                    }
                }
                else if (Reader.NodeType == XmlNodeType.Element && Reader.Name == "List") {
                    Reader.MoveToAttribute("Name");
                    if (mainNodes.Contains(Reader.Value))
                    {
                        string name = Reader.Value;
                        Dictionary<string, object> list = new Dictionary<string, object>();
                        while (Reader.Read())
                        {
                            string listType = "";
                            if (Reader.NodeType == XmlNodeType.EndElement && Reader.Name == "List") break;
                            if(Reader.NodeType==XmlNodeType.Element && Reader.Name == "Object") {
                                Reader.MoveToElement();
                                listType = Reader.Value;
                                Type innerType = Type.GetType(Reader.Name);
                                list.Add(listType, ReadObject(innerType));
                            }
                        }
                        innerConstr.Add(name,list.Values);
                    }
                }
            }
            return constructorInfo.Invoke(constructor.Sort(innerConstr).Values.ToArray()) as IXMLReflector;
        }
        protected override Dictionary<string,object> ReadFile(List<string> nodes)
        {
            Dictionary<string, object> mainValues = new Dictionary<string, object>();
            while (Reader.Read())
            {
                if(Reader.NodeType==XmlNodeType.Element && Reader.Name == "Field") {
                    Reader.MoveToFirstAttribute();
                    if (nodes.Contains(Reader.Value))
                    {
                        string varianceName = Reader.Value;
                        mainValues.Add(varianceName,ReadValue());
                    }
                }
            }
            Reader.Close();
            return mainValues;
        }
        protected override object ReadValue()
        {
            Reader.MoveToAttribute("Value");
            return Reader.Value;
        }
        protected XmlReader Reader { get; private set; }
        private StreamReader _stream;
    }
}
