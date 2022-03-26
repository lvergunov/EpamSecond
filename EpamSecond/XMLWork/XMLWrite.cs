using EpamTaskTwo.Measure;
using System.Collections;
using System.Reflection;
using System.Xml;

namespace EpamTaskTwo.XMLWork
{
    public class ClassicalWriterXML
    {
        public XmlWriter XmlWriter { get; private set; }
        public ClassicalWriterXML(IXMLReflector component, string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            string path = Directory.GetCurrentDirectory() + @"\XMLStorage\" + $"{filename}" + ".xml";
            XmlWriter = XmlWriter.Create(path, settings);
            AddWrites(component);
            XmlWriter.Close();
        }


        protected void AddWrites<T>(T component) where T : IXMLReflector
        {
            Type componentType = component.GetType();
            foreach (PropertyInfo field in componentType.GetProperties())
            {
                if (field.PropertyType.Namespace == "System.Collections.Generic")
                {
                    IList list = field.GetValue(component) as IList;
                    XmlWriter.WriteStartElement("List");
                    XmlWriter.WriteAttributeString("Name", $"{field.Name}");
                    if (list != null)
                    {
                        WriteArray(list);
                    }
                    XmlWriter.WriteEndElement();
                }
                else
                {
                    XmlWriter.WriteStartElement("Field");
                    XmlWriter.WriteAttributeString("Name", $"{field.Name}");
                    XmlWriter.WriteAttributeString("Type", $"{field.PropertyType.Name}");
                    if (field.PropertyType.GetInterface("IXMLReflector") != null)
                    {
                        if (field.GetValue(component) is IXMLReflector comp && comp != null)
                        {
                            XmlWriter.WriteStartElement("Object");
                            XmlWriter.WriteAttributeString("Name", $"{field.Name}");
                            XmlWriter.WriteStartElement(field.GetValue(component).GetType().FullName);
                            AddWrites(comp);
                            XmlWriter.WriteEndElement();
                            XmlWriter.WriteEndElement();
                            AddWrites(comp);
                        }
                    }
                    else if (field.GetValue(component) != null)
                    {
                        XmlWriter.WriteStartElement("Field");
                        XmlWriter.WriteAttributeString("Name", $"{field.Name}");
                        XmlWriter.WriteAttributeString("Type", $"{field.PropertyType.Name}");
                        XmlWriter.WriteAttributeString("Value", $"{field.GetValue(component)}");
                        XmlWriter.WriteEndElement();
                    }
                }
            }
        }
        private void WriteArray(IList list)
        {
            uint counter = 0;
            foreach (var el in list)
            {
                XmlWriter.WriteStartElement("ListElement");
                XmlWriter.WriteAttributeString("Number", $"{counter}");
                if (el is IXMLReflector comp)
                {
                    XmlWriter.WriteStartElement("Object");
                    XmlWriter.WriteStartElement(el.GetType().FullName);
                    AddWrites(comp);
                    XmlWriter.WriteEndElement();
                    XmlWriter.WriteEndElement();
                    XmlWriter.WriteStartElement(el.GetType().Name);
                    AddWrites(comp);
                    XmlWriter.WriteEndElement();
                }
                else
                {
                    XmlWriter.WriteAttributeString("ValueType", el.GetType().Name);
                    XmlWriter.WriteString($"{el}");
                    XmlWriter.WriteEndElement();
                }
                XmlWriter.WriteEndElement();
                counter++;
            }
        }
    }
}