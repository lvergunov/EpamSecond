using EpamTaskTwo.Matherials;
using EpamTaskTwo.Measure;
using EpamTaskTwo.XMLWork;
using EpamTaskTwo.ReadyProduct;
using Newtonsoft.Json;

namespace EpamTaskTwo.Storage
{
    public static class ObjectStorage
    {
        public static List<IComponent> Components { get; private set; }
        static ObjectStorage()
        {
            Components = new List<IComponent>();
        }
        public static void AddComponent(IComponent component)
        {
            Components.Add(component);
            RenewXLMS();
        }
        public static void RemoveComponent(IComponent component)
        {
            Components.Remove(component);
            RenewXLMS();
        }
        public static void ReplaceChipboard(IChipboard newChipboard, IChipboard oldChipboard)
        {
            RemoveComponent(oldChipboard);
            AddComponent(newChipboard);
        }
        internal static void RenewXLMS()
        {
            DirectoryInfo xmlDirectory = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\XMLStorage");
            foreach (FileInfo file in xmlDirectory.GetFiles())
            {
                file.Delete();
            }
            _lastNumber = 0;
            foreach (IComponent comp in Components)
            {
                ClassicalWriterXML writer = new ClassicalWriterXML(comp,$"{comp.GetType().Name}{_lastNumber}");
                _lastNumber++;
            }
            foreach (ITable comp in ReadyStorage.Tables)
            {
                ClassicalWriterXML writer = new ClassicalWriterXML(comp,$"{comp.GetType().Name}{_lastNumber}");
                _lastNumber++;
            }
        }
        public static void RemoveJsons()
        {
            _jsons.Clear();
            _lastNumber = 0;
        }
        public static void AddToJson(IXMLReflector component, string name)
        {
            _jsons.Add(name, JsonConvert.SerializeObject(component,
                new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto }
                ));
        }
        public static IXMLReflector GetFromJson(string name)
        {
            return JsonConvert.DeserializeObject<IXMLReflector>(_jsons[name]);
        }
        private static uint _lastNumber = 0;
        private static Dictionary<string, string> _jsons = new Dictionary<string, string>();
    }
}
