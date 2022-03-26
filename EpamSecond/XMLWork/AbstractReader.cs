namespace EpamTaskTwo.XMLWork
{
    public abstract class AbstractReader
    {
        protected abstract void ReadNewXML(string fileName);
        protected abstract Dictionary<string,object> ReadFile(List<string> nodes);
        protected abstract object ReadValue();
        protected abstract void ReadNewXML(string fileName, System.Text.Encoding encoding);
    }
}
