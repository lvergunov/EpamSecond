using System.Reflection;
using System.Collections;

namespace EpamTaskTwo.XMLWork
{
    public class WriterByStream
    {
        public WriterByStream(IXMLReflector component,uint fileNumber)
        {
            string path = Directory.GetCurrentDirectory() + @"\XMLStorage\" + $"{component.GetType().Name}" 
                + $"{fileNumber}.xml";
            using (Writer = new StreamWriter(path, true,System.Text.Encoding.UTF32))
            {
                CreateHeader(component);
            }
        }
        private async void CreateHeader(IXMLReflector component)
        {
            await Writer.WriteLineAsync("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            try
            {
                StartField("Object","Type",component.GetType().Name);
                CreateWrites(component);
            }
            finally
            {
                EndField("Object");
                Writer.Flush();
                Writer.Close();
            }
        }
        private async void CreateWrites<T>(T component) where T : notnull {
            PropertyInfo[] properties = component.GetType().GetProperties();
                foreach(PropertyInfo field in properties)
                {
                    if (field.PropertyType.Namespace == "System.Collections.Generic") {
                        StartField("List","Name",$"{field.Name}");
                        IList list = field.GetValue(component) as IList;
                    if (list != null)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            StartField("Element", "Number", $"{i}");
                            CreateWrites(list[i]);
                            EndField("Element");
                        }
                    }
                    EndField("List");
                    }   
                    else {
                        if (field.PropertyType is IXMLReflector comp) {
                        StartField("Object", "Name", $"{field.Name}");
                        StartField(field.GetValue(component).GetType().FullName);
                            CreateWrites(comp);
                        EndField(field.GetValue(component).GetType().FullName);
                        EndField("Object");
                        }
                        else {
                            StartField("Field","Name",$"{field.Name}","Type",$"{field.PropertyType.Name}",
                                "Value",$"{field.GetValue(component)}");
                            EndField("Field");
                        }
                    }
                }
        }
        private async void StartField(string fieldTag,params string[] attributesWithVal)
        {
            await Writer.WriteAsync($"<{fieldTag}");
            for (int i=0;i<attributesWithVal.Length;i+=2)
            {
                await Writer.WriteAsync($" {attributesWithVal[i]}=\"{attributesWithVal[i+1]}\"");
            }
            await Writer.WriteAsync(">\n");
        }
        private async void EndField(string fieldName)
        {
            await Writer.WriteAsync($"</{fieldName}>\n");
        }
        protected StreamWriter Writer { get; }
        protected string FilePath { get; }
    }
}
