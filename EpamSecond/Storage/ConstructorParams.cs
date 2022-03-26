using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Storage
{
    /// <summary>
    /// class for working with objects and types when reading a file
    /// </summary>
    public class ConstructorParams
    {
        public virtual List<string> GetNodeNames(string objectName) {
            string[] temp = objectName.Split('.');
            objectName = temp[temp.Length-1];
            List<string> nodes = new List<string>();
            _order = objectName;
            switch (objectName)
            {
                case "FullChipboard":
                    nodes.AddRange(new string[] { "Length","Width","Height"}.ToList());
                    break;
                case "DeformedChipboard":
                    nodes.AddRange(new string[] { "Length", "Width", "Height","Cuts","ControlPoints" }.ToList());
                    break;
                case "Machine":
                    nodes.AddRange(new string[] {"MaxPossibleLength", "MaxPossibleWidth", "MaxPossibleHeight",
            "AllowNonRectangular","CostOfMM"});
                    break;
                case "CircleLeg":
                    nodes.AddRange(new string[] {"Matherial","Cost"});
                    break;
                case "OvalLeg":
                    nodes.AddRange(new string[] { "Matherial", "TotalCost"});
                    break;
                case "RectangularLeg":
                    nodes.AddRange(new string[] {"Matherial"});
                    break;
                case "RectangularCut":
                    nodes.AddRange(new string[] { "Length", "Width", "Height", 
                    "Form","Machine"});
                    break;
                case "Paper":
                    nodes.AddRange(new string[] { "Length", "Width", "Height",
                    "CostOfMM"});
                    break;
                case "Plastic":
                    nodes.AddRange(new string[] { "Length", "Width", "Height",
                    "CostOfMM"});
                    break;
                case "Steel":
                    nodes.AddRange(new string[] { "Length", "Width", "Height"});
                    break;
                case "PaperPasting":
                    nodes.AddRange(new string[] { "NecessaryMatherial", "Countertop" });
                    break;
                case "PlasticInsert":
                    nodes.AddRange(new string[] { "NecessaryMatherial", "Countertop" });
                    break;
                case "Furniture":
                    nodes.AddRange(new string[] {"TotalCost"});
                    break;
                case "Table":
                    nodes.AddRange(new string[] { "Countertop", "Legs", "Operations",
                    "Name","Furnitures"});
                    break;
                case "Point":
                    nodes.AddRange(new string[] { "X","Y","Z"});
                    break;
            }
            return nodes;
        }
        public virtual object Parse(string type,string value) {
            if (type == "FormType")
            {
                switch (value)
                {
                    case "Rectangular":
                        return FormTypes.Rectangular;

                    case "NonRectangular":
                        return FormTypes.NonRectangular;

                }
            }
            switch (type)
            {
                case "Double":
                    return Convert.ToDouble(value);
                case "Boolean":
                    return Convert.ToBoolean(value);

                default:
                    throw new ArgumentException("Unknown type");
            }
        }

        /// <summary>
        /// a method that places the parameters for the constructor in the correct order
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual Dictionary<string,object> Sort(Dictionary<string, object> values)
        {
            List<string> order = GetNodeNames(_order);
            Dictionary<string, object> sortedDictionary = new Dictionary<string, object>();
            foreach (string st in order)
            {
                sortedDictionary.Add(st,values[st]);
            }
            return sortedDictionary;
        }
        private string _order;
    }
}
